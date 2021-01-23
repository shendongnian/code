        public void ReceiveMessage(IAsyncResult ar) 
        {
            int bytesRead;
            try
            {
                lock (client1.GetStream()) 
                {
                    bytesRead = client1.GetStream().EndRead(ar);
                }
                string messageReceived = System.Text.Encoding.ASCII.GetString(data, 0, bytesRead);
                received = messageReceived;
                int firstindex = received.IndexOf((char)2);
                int lastindex = received.IndexOf((char)3);
                if (firstindex > 0 && lastindex > 0)
                {
                    string first = received.Substring(firstindex, 1);
                    string last = received.Substring(lastindex, 1);
                }
                lock (client1.GetStream())
                {
                    client1.GetStream().BeginRead(data, 0, System.Convert.ToInt32(client1.ReceiveBufferSize), ReceiveMessage, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
