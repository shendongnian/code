    string input = "hello world";
    System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
    var array = enc.GetBytes(input);
    byte chksum = 0;
    foreach(byte data in array)
    {
       chksum += data;
    }
