    private void button1_Click(object sender, EventArgs e)
    {   
    System.Threading.Thread Server_thread = new Thread(My_Send_Function);
    Server_thread .Start();
    }
    private void My_Send_Function()
    {   
        try
        {
        String text = textBox1.Text;
        UdpClient udpc = new UdpClient(text,8899);
        IPEndPoint ep = null;
        while (true)
        {
            MessageBox.Show("Name: ");
            string name = textBox2.Text;
            if (name == "") break;
            byte[] sdata = Encoding.ASCII.GetBytes(name);
            udpc.Send(sdata, sdata.Length);
            if (udpc.Receive(ref ep)==null)
            {
               MessageBox.Show("Host not found");
            }
            else
            {
                byte[] rdata = udpc.Receive(ref ep);
                string job = Encoding.ASCII.GetString(rdata);
                MessageBox.Show(job);
            }
        }
        }
            catch
             {
               MessageBox.Show("Error Restarting");
            }
    }
