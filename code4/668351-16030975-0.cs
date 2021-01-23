    IPAddress ip = IPAddress.Parse(txtWrite.Text);
    Byte[] bytes = ip.GetAddressBytes();
    for (int i = 0; i < bytes.Length; i++)
    {
        string str = bytes[i].ToString();
        MessageBox.Show(str);
        if(i < bytes.Length - 1)//Try this out
        {
            serialPort1.Write(str+".");
        }
     }
     serialPort1.Write("\r\n");
