    using System.IO;
    using System.Net.NetworkInformation;
    using System.Net.Security;
    using System.Net.Sockets;
    public partial class Default3 : System.Web.UI.Page
    {
      protected void Page_Load(object sender, EventArgs e)
    {
        // create an instance of TcpClient 
        TcpClient tcpclient = new TcpClient();
        tcpclient.Connect("pop3.live.com", 995);
        System.Net.Security.SslStream sslstream = new SslStream(tcpclient.GetStream());
        sslstream.AuthenticateAsClient("pop3.live.com");
        StreamWriter sw = new StreamWriter(sslstream);
        System.IO.StreamReader reader = new StreamReader(sslstream);
        sw.WriteLine("USER xxx@live.com"); sw.Flush();
        sw.WriteLine("PASS xxxx****"); sw.Flush();
        sw.WriteLine("RETR 1");
        sw.Flush();
        sw.WriteLine("Quit ");
        sw.Flush();
        string str = string.Empty;
        string strTemp = string.Empty;
        while ((strTemp = reader.ReadLine()) != null)
        {
            if (".".Equals(strTemp))
            {
                break;
            }
            if (strTemp.IndexOf("-ERR") != -1)
            {
                break;
            }
            str += strTemp;
        }
        Response.Write(str);
        reader.Close();
        sw.Close();
        tcpclient.Close(); // close the connection
    }
    }
