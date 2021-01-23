    using System;
    using System.Windows.Forms;
    using System.Text;
    using System.Net.Sockets;
    using System.Threading;
    namespace testClient100
    {
    public partial class Form1 : Form
    {
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string readData = null;
        string ipaddress;
        public Form1()
        {
            InitializeComponent();
        }
        private void getMessage()
        {
            while (true)
            {
                serverStream = clientSocket.GetStream();
                int buffSize = 0;
                byte[] inStream = new byte[10025];
                buffSize = clientSocket.ReceiveBufferSize;
                serverStream.Read(inStream, 0, buffSize);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                readData = "" + returndata;
                msg();
            }
        }
        private void msg()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(msg));
            else
                textBox1.Text = textBox1.Text + Environment.NewLine + " >> " + readData;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(textBox2.Text);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            ipaddress = textBox4.Text;
            readData = "Conected to Chat Server ...";
            msg();
            clientSocket.Connect(ipaddress, 8888);
            serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(textBox3.Text);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            Thread ctThread = new Thread(getMessage);
            ctThread.Start();
        }
    }
    }
