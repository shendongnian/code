        while (true)
        {
            MessageBox.Show("Name: ");
            string name = "Connected";
            if (name == "") break;
            byte[] sdata = Encoding.ASCII.GetBytes(name);
            try{
                udpc.Send(sdata, sdata.Length);
                byte[] rdata = udpc.Receive(ref ep);
                string job = Encoding.ASCII.GetString(rdata);
                MessageBox.Show(job);
            }
            catch(Exception ex)
            {
                MessaageBox.show(ex.toString());
            }
        }
