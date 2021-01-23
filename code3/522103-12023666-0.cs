    private void button_Click(object sender, EventArgs e)
    {
        var sb = new StringBuilder();
        Color originalColor = txtcomputers.SelectionColor; ;
        for (int i = 0; i < txtcomputers.Lines.Count(); i++)
        {
            var line = txtcomputers.Lines[i];
            string strhost = line;
            if (strhost.Length > 0)
            {
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();
                options.DontFragment = true;
                // Create a buffer of 32 bytes of data to be transmitted.   
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;
                try
                {
                    PingReply reply = pingSender.Send(strhost, timeout, buffer, options);
                    txtcomputers.SelectionStart = txtcomputers.GetFirstCharIndexFromLine(i);
                    txtcomputers.SelectionLength = strhost.Length;
                        
                    if (reply.Status == IPStatus.Success)
                    {
                        txtcomputers.SelectionColor = Color.Green;
                    }
                    else
                    {
                        txtcomputers.SelectionColor = Color.Red;
                    }
                       
                        
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                txtcomputers.SelectionLength = 0;
            }
        }
        txtcomputers.SelectionColor = originalColor;
    }
