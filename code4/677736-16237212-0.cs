    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form4 : Form
        {
            private Thread _listenThread;
            private UdpClient _listener;
    
            public Form4()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                this._listenThread = new Thread(new ThreadStart(this.StartListening));
                this._listenThread.Start();
            }
    
            private void StartListening()
            { 
                
                IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 35555);
                IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
    
                this._listener = new UdpClient(localEndPoint);
    
                try
                {
                    do
                    {
                        byte[] received = this._listener.Receive(ref remoteIpEndPoint);
    
                        MessageBox.Show(Encoding.ASCII.GetString(received));
    
                    }
                    while (this._listener.Available == 0);
                }
                catch (Exception ex)
                {
                    //handle Exception
                }
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 35556);
                IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 35555);
    
                UdpClient caller = new UdpClient(localEndPoint);
    
                caller.Send(Encoding.ASCII.GetBytes("Hello World!"), 12, remoteIpEndPoint);
    
                caller.Close();
            }
    
            protected override void OnFormClosing(FormClosingEventArgs e)
            {
                base.OnFormClosing(e);
    
                this._listener.Close();
    
                this._listenThread.Abort();
                this._listenThread.Join();
    
                this._listenThread = null;
            }    
        }
    }
