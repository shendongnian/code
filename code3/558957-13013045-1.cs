    public string GetMessageString()
    {
        this.ReturnData.WaitOne();
        return this.Message;
    }
    public byte[] GetMessageBytes(){
        this.ReturnData.WaitOne();
        return encoder.GetBytes(Message);
    }
