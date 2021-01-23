        sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if(e.EventType != SerialData.Chars)
            {
                tbStatus.Text = "IGNORED: " + e.EventType.ToString();
                return;
            }
            try
            {
                int nBytesToRead = sp.BytesToRead;
                char[] receivedData = new char[nBytesToRead];
                sp.Read(receivedData, 0, nBytesToRead);
                tbStatus.Text = "RECEIVED: " + new string(receivedData);
            }
            catch (Exception ex)
            {
                tbStatus.Text = "ERROR: " + ex.Message;
            }
        }
