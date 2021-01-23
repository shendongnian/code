    {
      UdpClient udpclient = new UdpClient();
      try
      {
       if (connect == true && MuteMic.Checked == false)
       {
               udpclient.Send(e.Buffer, e.BytesRecorded, otherPartyIP.Address.ToString(), 1500);
       }
      }
      finally
      {
        if (udpclient!= null)
          udpclient.Dispose();
      }
    }
