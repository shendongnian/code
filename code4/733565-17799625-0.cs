    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // initialise the ConnectUDP method on a pooled thread
            // Note: could do this from the onLoad event too
            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(ConnectUDP));
    
        // This function just invokes the main UI thread if required
        private static void UIThread(Control c, MethodInvoker code)
        {
            if (control.InvokeRequired)
            {
               control.BeginInvoke(code);
               return;
            }
            control.Invoke(code);
        }
        private void ConnectUDP(object obj)
        {
            UdpClient subscriber = new UdpClient(8899);
            IPAddress addr = IPAddress.Parse("230.0.0.1");
            subscriber.JoinMulticastGroup(addr);
            IPEndPoint ep = null;
            for (int i = 0; i < 10; i++)
            {
                byte[] pdata = subscriber.Receive(ref ep);
                string price = Encoding.ASCII.GetString(pdata);
                // Update the label on the main UI thread
                UIThread(label1, delegate {
                    label1.Text += price;
                });
            }
            subscriber.DropMulticastGroup(addr);
        }
    }
