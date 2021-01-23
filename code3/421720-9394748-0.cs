Code for a UPnP library:
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Xml;
using System.IO;
namespace UPNPLib
{
    public class RouterElement
    {
        public RouterElement()
        {
        }
        public override string ToString()
        {
            return Name;
        }
        public List<RouterElement> children = new List<RouterElement>();
        public RouterElement parent;
        public string Name;
        public string Value;
        public RouterElement this[string name] {
            get
            {
                foreach (RouterElement et in children)
                {
                    if (et.Name.ToLower().Contains(name.ToLower()))
                    {
                        return et;
                    }
                }
                foreach (RouterElement et in children)
                {
                    Console.WriteLine(et.Name);
                }
                throw new KeyNotFoundException("Unable to find the specified entry");
            }
    }
        public RouterElement(XmlNode node, RouterElement _parent)
        {
            Name = node.Name;
            if (node.ChildNodes.Count < 1)
            {
                Value = node.InnerText;
            }
            else
            {
                if (node.ChildNodes[0].Name.ToLower().Contains("#text"))
                {
                    Value = node.InnerText;
                }
                else
                {
                    Value = "";
                    foreach (XmlNode et in node.ChildNodes)
                    {
                        children.Add(new RouterElement(et, this));
                    }
                }
            }
            parent = _parent;
            
        }
    }
    public class UPNP
    {
        
        /// <summary>
        /// Gets the root URL of the device
        /// </summary>
        /// <returns></returns>
        public static string GetRootUrl()
        {
            StringBuilder mbuilder = new StringBuilder();
            mbuilder.Append("M-SEARCH * HTTP/1.1\r\n");
            mbuilder.Append("HOST: 239.255.255.250:1900\r\n");
            mbuilder.Append("ST:upnp:rootdevice\r\n");
            mbuilder.Append("MAN:\"ssdp:discover\"\r\n");
            mbuilder.Append("MX:3\r\n\r\n");
            UdpClient mclient = new UdpClient();
            byte[] dgram = Encoding.ASCII.GetBytes(mbuilder.ToString());
            mclient.Send(dgram,dgram.Length,new IPEndPoint(IPAddress.Broadcast,1900));
            IPEndPoint mpoint = new IPEndPoint(IPAddress.Any, 0);
            rootsearch:
            dgram = mclient.Receive(ref mpoint);
            string mret = Encoding.ASCII.GetString(dgram);
            string orig = mret;
            mret = mret.ToLower();
            string url = orig.Substring(mret.IndexOf("location:") + "location:".Length, mret.IndexOf("\r", mret.IndexOf("location:")) - (mret.IndexOf("location:") + "location:".Length));
            WebClient wclient = new WebClient();
            try
            {
                Console.WriteLine("POLL:" + url);
                string reply = wclient.DownloadString(url);
                if (!reply.ToLower().Contains("router"))
                {
                    goto rootsearch;
                }
            }
            catch (Exception)
            {
                goto rootsearch;
            }
            return url;
        }
        public static RouterElement enumRouterFunctions(string url)
        {
            
            XmlReader mreader = XmlReader.Create(url);
            XmlDocument md = new XmlDocument();
            md.Load(mreader);
            XmlNodeList rootnodes = md.GetElementsByTagName("serviceList");
            RouterElement elem = new RouterElement();
            foreach (XmlNode et in rootnodes)
            {
                RouterElement el = new RouterElement(et, null);
                elem.children.Add(el);
            }
            
            return elem;
        }
        public static RouterElement getRouterInformation(string url)
        {
            XmlReader mreader = XmlReader.Create(url);
            XmlDocument md = new XmlDocument();
            md.Load(mreader);
            XmlNodeList rootnodes = md.GetElementsByTagName("device");
            return new RouterElement(rootnodes[0], null);
        }
        
    }
    public class RouterMethod
    {
        string url;
        public string MethodName;
        string parentname;
        string MakeRequest(string URL, byte[] data, string[] headers)
        {
            Uri mri = new Uri(URL);
            TcpClient mclient = new TcpClient();
            mclient.Connect(mri.Host, mri.Port);
            Stream mstream = mclient.GetStream();
            StreamWriter textwriter = new StreamWriter(mstream);
            textwriter.Write("POST "+mri.PathAndQuery+" HTTP/1.1\r\n");
         
            textwriter.Write("Connection: Close\r\n");
     
            textwriter.Write("Content-Type: text/xml; charset=\"utf-8\"\r\n");
          
            foreach (string et in headers)
            {
                textwriter.Write(et + "\r\n");
            }
            textwriter.Write("Content-Length: " + (data.Length).ToString()+"\r\n");
            textwriter.Write("Host: " + mri.Host+":"+mri.Port+"\r\n");
         
            
            textwriter.Write("\r\n");
            textwriter.Flush();
          
        
            Stream reqstream = mstream;
            reqstream.Write(data, 0, data.Length);
            reqstream.Flush();
            StreamReader reader = new StreamReader(mstream);
            while (reader.ReadLine().Length > 2)
            {
            
            }
            return reader.ReadToEnd();
        }
        public RouterElement Invoke(string[] args)
        {
           
            MemoryStream mstream = new MemoryStream();
            StreamWriter mwriter = new StreamWriter(mstream);
            //TODO: Implement argument list
            string arglist = "";
            
            mwriter.Write("<?xml version=\"1.0\"?>" + "<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" SOAP-ENV:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">" + "<SOAP-ENV:Body>");
         
            mwriter.Write("<m:" + MethodName + " xmlns:m=\""+parentschema+"\"/>");//" + arglist + "</m:" + MethodName + ">");
            mwriter.Write("</SOAP-ENV:Body></SOAP-ENV:Envelope>");
            mwriter.Flush();
            List<string> headers = new List<string>();
            headers.Add("SOAPAction: \"" + parentschema + "#" + MethodName + "\"");
          
            mstream.Position = 0;
            byte[] dgram = new byte[mstream.Length];
         
            mstream.Read(dgram, 0, dgram.Length);
            
            XmlDocument mdoc = new XmlDocument();
            string txt = MakeRequest(url, dgram, headers.ToArray());
            mdoc.LoadXml(txt);
            try
            {
                RouterElement elem = new RouterElement(mdoc.ChildNodes[0], null);
                return elem["Body"].children[0];
            }
            catch (Exception er)
            {
                RouterElement elem = new RouterElement(mdoc.ChildNodes[1], null);
                return elem["Body"].children[0];
            }
            
        }
        public List<String> parameters = new List<string>();
        string baseurl;
        string parentschema;
        public RouterMethod(string svcurl, RouterElement element,string pname, string baseURL, string svcpdsc)
        {
            parentschema = svcpdsc;
            baseurl = baseURL;
            parentname = pname;
            url = svcurl;
            MethodName = element["name"].Value;
            try
            {
                foreach (RouterElement et in element["argumentList"].children)
                {
                    parameters.Add(et.children[0].Value);
                }
            }
            catch (KeyNotFoundException)
            {
            }
        }
    }
    public class RouterService
    {
        string url;
        public string ServiceName;
        public List<RouterMethod> methods = new List<RouterMethod>();
        public RouterMethod GetMethodByNonCaseSensitiveName(string name)
        {
            foreach (RouterMethod et in methods)
            {
                if (et.MethodName.ToLower() == name.ToLower())
                {
                    return et;
                }
            }
            throw new KeyNotFoundException();
        }
        public RouterService(RouterElement element, string baseurl)
        {
            
            ServiceName = element["serviceId"].Value;
            url = element["controlURL"].Value;
            WebClient mclient = new WebClient();
            string turtle = element["SCPDURL"].Value;
            if (!turtle.ToLower().Contains("http"))
            {
                turtle = baseurl + turtle;
            }
            Console.WriteLine("service URL " + turtle);
            string axml = mclient.DownloadString(turtle);
            XmlDocument mdoc = new XmlDocument();
            if (!url.ToLower().Contains("http"))
            {
                url = baseurl + url;
            }
            mdoc.LoadXml(axml);
            XmlNode mainnode = mdoc.GetElementsByTagName("actionList")[0];
            RouterElement actions = new RouterElement(mainnode, null);
            foreach (RouterElement et in actions.children)
            {
                RouterMethod method = new RouterMethod(url, et,ServiceName,baseurl,element["serviceType"].Value);
                methods.Add(method);
            }
        }
    }
}
Code for a bandwidth meter:
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UPNPLib;
using System.IO;
namespace bandwidthmeter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BinaryReader mreader = new BinaryReader(File.Open("bandwidthlog.txt", FileMode.OpenOrCreate));
            if (mreader.BaseStream.Length > 0)
            {
                prevsent = mreader.ReadInt64();
                prevrecv = mreader.ReadInt64();
            }
            mreader.Close();
            List<RouterService> services = new List<RouterService>();
            string fullurl = UPNP.GetRootUrl();
            RouterElement router = UPNP.enumRouterFunctions(fullurl);
            Console.WriteLine("Router feature enumeration complete");
            foreach (RouterElement et in router.children)
            {
                services.Add(new RouterService(et.children[0], fullurl.Substring(0, fullurl.IndexOf("/", "http://".Length+1))));
            }
            getReceiveDelegate = services[1].GetMethodByNonCaseSensitiveName("GetTotalBytesReceived");
            getSentDelegate = services[1].GetMethodByNonCaseSensitiveName("GetTotalBytesSent");
            Console.WriteLine("Invoking " + getReceiveDelegate.MethodName);
            //Console.WriteLine(services[1].GetMethodByNonCaseSensitiveName("GetTotalPacketsSent").Invoke(null));
         
            Timer mymer = new Timer();
            mymer.Tick += new EventHandler(mymer_Tick);
            mymer.Interval = 1000;
            mymer.Start();
            FormClosed += new FormClosedEventHandler(Form1_FormClosed);
        }
        long prevsent = 0;
        long prevrecv = 0;
        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            BinaryWriter mwriter = new BinaryWriter(File.Open("bandwidthlog.txt", FileMode.OpenOrCreate));
            mwriter.Write(getsent());
            mwriter.Write(getreceived());
            mwriter.Flush();
            mwriter.Close();
            
        }
        long getsent()
        {
            long retval = Convert.ToInt64(getSentDelegate.Invoke(null).children[0].Value);
            if (prevsent > retval)
            {
                retval = prevsent + retval;
            }
            return retval;
        }
        long getreceived()
        {
            long retval = Convert.ToInt64(getReceiveDelegate.Invoke(null).children[0].Value);
            if (prevrecv > retval)
            {
                retval = prevrecv + retval;
            }
            return retval;
        }
        void mymer_Tick(object sender, EventArgs e)
        {
            label1.Text = "Sent: "+(getsent()/1024/1024).ToString()+"MB\nReceived: "+(getreceived()/1024/1024).ToString()+"MB";
            
        }
        RouterMethod getSentDelegate;
        RouterMethod getReceiveDelegate;
        
    }
}
