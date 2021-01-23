    void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        string str = e.Data;
        byte[] bytes = Encoding.ASCII.GetBytes(str); //or replace ASCII with your favorite
        //encoding
        OutputData.AddRange(bytes);
    }
