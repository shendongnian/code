    List<byte> OutputData = new List<byte>(); //global
    
    void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        string str = e.Data;
        byte[] bytes = new byte[str.Length * sizeof(char)];
        System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
        OutputData.AddRange(bytes);
    }
