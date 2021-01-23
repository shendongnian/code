    String text = textBox1.Text;
    UdpClient udpc = new UdpClient(text,8899);
    IPEndPoint ep = null;
    while (true)
    {
     MessageBox.Show("Name: ");
     string name = "Connected";
     if (name == "") break; //This will never happen because you have already set the value
     byte[] sdata = Encoding.ASCII.GetBytes(name);
     int dataSent = 0;    
    try
    {
       dataSent = udpc.Send(sdata, sdata.Length);
    }
    catch(Exception e)
    {
       dataSent = 0;
       //There is an exception. Probably the host is wrong
    }
    if (dataSent>0)
    {
       try
       {
          byte[] rdata = udpc.Receive(ref ep);
          if(rdata!=null && rdata.Length > 0)
          {
          string job = Encoding.ASCII.GetString(rdata);
          MessageBox.Show(job)
          //True here as we managed to recieve without going to the catch statement
          //and we actually have data in the byte[]
          }
          else
          {
             MessageBox.Show("We did not recieve any data");
             //False here, because the array was empty.
          }
       }
       catch(Exception udpe)
       {
          //False here as we had a socket exception or timed out
          MessageBox.Show(udpe.ToString());
       }
    }
}
