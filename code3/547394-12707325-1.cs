    public void ConnectToSelectedDevice()
    {
        mComm.SetAddress(0x40);
        Byte[] buffer= new Byte[2];
        buffer[0] = 0x24;
        buffer[1] = 0x00;
        if(this.IsChecked)
        {
         buffer[1] = 0x04;
        }
        mComm.WriteBytes(2, buffer);
    }
