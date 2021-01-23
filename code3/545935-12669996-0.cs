    private void button1_Click(object sender, EventArgs e)
    {
         //Send the input message using a form input like RichTextBox control.
         string text = this.richTextBox1.Text;
         UdpClient udpc = new UdpClient(text, 2055);
         IPEndPoint ep = null;
         while (true)
         {
            string name = this.richTextBox2.Text;
            if (name == "") break;
            byte[] sdata = Encoding.ASCII.GetBytes(name);
            udpc.Send(sdata, sdata.Length);
            byte[] rdata = udpc.Receive(ref ep);
            string job = Encoding.ASCII.GetString(rdata);
            this.label1.Text = job;
        }
    }
