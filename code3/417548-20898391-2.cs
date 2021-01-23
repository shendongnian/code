    using System;
     using System.Collections.Generic;
     using System.ComponentModel;
     using System.Data;
     using System.Drawing;
     using System.Linq;
     using System.Text;
     using System.Windows.Forms;
     using System.Net;
     using System.Net.Sockets;
     using System.Threading;
     using System.IO;
     using System.Collections;
     namespace Myserver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
     
        string multicastip = string.Empty;
        string serversystemname = string.Empty;
        string receiveddata = string.Empty;
        string nodeinfo = string.Empty;
        string clientHostName = string.Empty;
        string clientIP = string.Empty;
        string Nodeid = string.Empty;
        int multicastport = 0;
        int clientport = 0;
        
        DataTable datatable;
        DataTable dataTableAddRemove;
        string[] splitReceived;
        string[] splitnodeinfo;
        Socket socket;
        IPAddress ipaddress;
        IPEndPoint ipendpoint;
        byte[] bytereceive;
        Dictionary<string, string> dictionarytable;
        public delegate void updategrid();
        private void Form1_Load(object sender, EventArgs e)
        {
            multicastip = "224.5.6.7";
            multicastport = 5000;
            serversystemname = Dns.GetHostName();
            datatable = new DataTable();
            datatable.Columns.Add("HostName");
            datatable.Columns.Add("Nodeid");
            datatable.Columns.Add("ipaddress");
            datatable.Columns.Add("portnumber");
            DGV.DataSource = datatable;
            Thread threadreceive = new Thread(receiver);
            threadreceive.Start();
        }
        void receiver()
        {
            dictionarytable = new Dictionary<string, string>();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            ipendpoint = new IPEndPoint(IPAddress.Any, multicastport);
            socket.Bind(ipendpoint);
            ipaddress = IPAddress.Parse(multicastip);
            socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(ipaddress, IPAddress.Any));
            while (true)
            {
                bytereceive = new byte[4200];
                socket.Receive(bytereceive);
                receiveddata = Encoding.ASCII.GetString(bytereceive, 0, bytereceive.Length);
                splitReceived = receiveddata.Split('@');
                if (splitReceived[0].ToString() == "connect")
                {
                    nodeinfo = splitReceived[1].ToString();
                    connect();
                }
                else if (splitReceived[0].ToString() == "Disconnect")
                {
                    nodeinfo = splitReceived[1].ToString();
                    Thread threadDisconnect = new Thread(disconnect);
                    threadDisconnect.Start();
                }
                else if (splitReceived[0].ToString() == "message")
                {
                   string[] str = splitReceived[1].Split('$');
                    
                    listBox1.Items.Add(str[0]+" -> "+str[1]);
                }
            }
        }
        void connect()
        {
            SocketSending socketsending = new SocketSending();
            int count = 0;
            splitnodeinfo = nodeinfo.Split('#');
            clientHostName = splitnodeinfo[0].ToString();
            clientIP = splitnodeinfo[1].ToString();
            clientport = Convert.ToInt32(splitnodeinfo[2].ToString());
            Nodeid = splitnodeinfo[3].ToString();
            if (!dictionarytable.ContainsKey(Nodeid))
            {
                count++;
                dictionarytable.Add(Nodeid, clientIP + "#" + clientport + "#" + clientHostName);
                dataTableAddRemove = (DataTable)DGV.DataSource;
                DataRow dr = dataTableAddRemove.NewRow();
                dr["Nodeid"] = Nodeid;
                dr["HostName"] = clientHostName;
                dr["IPAddress"] = clientIP;
                dr["portNumber"] = clientport;
                dataTableAddRemove.Rows.Add(dr);
                datatable = dataTableAddRemove;
                updatenodegrid();
            }
        }
        void disconnect()
        {
            SocketSending socketsending = new SocketSending();
            string removeClient = string.Empty;
            splitnodeinfo = nodeinfo.Split('#');
            clientHostName = splitnodeinfo[0].ToString();
            Nodeid = splitnodeinfo[1].ToString();
            dataTableAddRemove = (DataTable)DGV.DataSource;
            DataRow[] arrayDataRow = dataTableAddRemove.Select();
            for (int i = 0; i < arrayDataRow.Length; i++)
            {
                string matchGridHostName = arrayDataRow[i]["HostName"].ToString();
                if (clientHostName == matchGridHostName)
                {
                    Thread.Sleep(100);
                    removeClient = clientHostName;
                    arrayDataRow[i].Delete();
                     break;
                }
            }
            if (dictionarytable.ContainsKey(removeClient))
            {
                dictionarytable.Remove(removeClient);
            }
        }
        void updatenodegrid()
        {
            if (this.DGV.InvokeRequired)
                this.DGV.Invoke(new updategrid(updatenodegrid));
            else
                DGV.DataSource = datatable;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dictionarytable.Clear();
        }
    }
