    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Net;
    using System.Threading;
    using System.Windows.Forms;
    namespace testServer
    {
    class Program
    {
        static Form1 form1 = new Form1();
        static Form2 form2 = new Form2();
        static byte[] buffer { get; set; }
        static Socket sck, acc;
        static string name;
        public void setName(string s)
        {
            name = s;
            string[] asdf = new string[2];
        }
        static string getIP()
        {
            string hostName = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(hostName);
            IPAddress[] addr = ipEntry.AddressList;
            return addr[addr.Length - 1].ToString();
        }
        static void Main(string[] args)
        {
            if (name == null)
            {
                Thread t = new Thread(ThreadProc);
                t.Start();
            } 
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Bind(new IPEndPoint(0, 8888));
            Console.WriteLine("Your local IP address is: " + getIP());
            Console.WriteLine("Awaiting Connection");
            sck.Listen(100);
            acc = sck.Accept();
            Console.WriteLine(" >> Accept connection from client");
            sendMsg();
            while (acc.Connected)
            {
                Thread.Sleep(500);
                byte[] Buffer = new byte[255];
                int receive = acc.Receive(Buffer, 0, Buffer.Length, 0);
                Array.Resize(ref Buffer, receive);
                form2.SetText(Encoding.Default.GetString(Buffer));
            }
        }
        public void btnClick(string s)
        {
            name = s;
            Console.WriteLine("Name: " + name);
            System.Threading.Thread r = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc2));
            r.Start();
        }
        public void sendMSG(string s)
        {
                try
                {
                    buffer = Encoding.Default.GetBytes(s);
                    acc.Send(buffer);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
        }
        static void sendMsg()
            {
                try
                {
                    buffer = Encoding.Default.GetBytes(name);
                    acc.Send(buffer);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
        }
        public static void ThreadProc()
        {
            form1.ShowDialog();
        }
        public static void ThreadProc2()
        {
            form2.ShowDialog();
        }
    }
    }
