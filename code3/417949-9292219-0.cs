    private void BackGroundGetServerData(object sender, DoWorkEventArgs e)
    {
        while(true)
        {
            Byte[] dataArray = new Byte[2];
            try
            {
                _DataStream.Read(dataArray, 0, 2);
                String reply = System.Text.Encoding.ASCII.GetString(dataArray);
                e.Result = reply;
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
