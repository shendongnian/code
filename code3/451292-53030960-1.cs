       public partial class Form1 : Form
        {
            private Thread n_server;
            private Thread n_client;
            private Thread n_send_server;
            private TcpClient client;
            private TcpListener listener;
            private int port = 2222;
            private string IP = " ";
            private Socket socket;
            byte[] bufferReceive = new byte[4096];
            byte[] bufferSend = new byte[4096];
            public Form1()
            {
                InitializeComponent();
            }
    
            private void exitToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }
    
            public void Server()
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                try
                {
                    socket = listener.AcceptSocket();
                    if (socket.Connected)
                    {
                        textBox3.Invoke((MethodInvoker)delegate { textBox3.Text = "Client        : " + socket.RemoteEndPoint.ToString(); });
                    }
                    while (true)
                    {
                        int length = socket.Receive(bufferReceive);
                        if (length > 0)
                        {
                            label2.Invoke((MethodInvoker)delegate { label2.Text = Encoding.Unicode.GetString(bufferReceive); });
                        }
                    }
                }
                catch
                {
                }
            }
    
            public void Client()
            {
                IP = "localhost";
                client = new TcpClient();
                try
                {
                    client.Connect(IP, port);
                    while (true)
                    {
                        NetworkStream nts = client.GetStream();
                        int length;
                        while ((length = nts.Read(bufferReceive, 0, bufferReceive.Length)) != 0)
                        {
                           label3.Invoke((MethodInvoker)delegate { label3.Text = Encoding.Unicode.GetString(bufferReceive); });
                        }
                    }
                }
    
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
    
                if (client.Connected)
                {
                    textBox3.Invoke((MethodInvoker)delegate { textBox3.Text = "Connected..."; });
    
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                n_server = new Thread(new ThreadStart(Server));
                n_server.IsBackground = true;
                n_server.Start();
                textBox1.Text = "Server up";
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                n_client = new Thread(new ThreadStart(Client));
                n_client.IsBackground = true;
                n_client.Start();
            }
    
            private void send()
            {
                if (socket!=null)
                {
                    bufferSend = Encoding.Unicode.GetBytes(textBox2.Text);
                    socket.Send(bufferSend);
                }
                else
                {
                    if (client.Connected)
                    {
                        bufferSend = Encoding.Unicode.GetBytes(textBox3.Text);
                        NetworkStream nts = client.GetStream();
                        if (nts.CanWrite)
                        {
                            nts.Write(bufferSend,0,bufferSend.Length);
                        }
    
                    }
                }
            }
    
    
    
            private void button3_Click(object sender, EventArgs e)
            {
                n_send_server = new Thread(new ThreadStart(send));
                n_send_server.IsBackground = true;
                n_send_server.Start();
            }
        }
