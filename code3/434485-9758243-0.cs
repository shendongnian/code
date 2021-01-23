    Response.ContentType = "text/event-stream";
    while (true)
    {
      Response.Write(string.Format("data: {0}\n\n", DateTime.Now.ToString()));
      Response.Flush();
      if (Response.IsClientConnected == false)
      {
        break;
      }
      System.Threading.Thread.Sleep(1000);
    }
