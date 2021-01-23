      try
      {
          webResponse = webRequest.GetResponse();
      }
      catch 
      {
          ImageExists = false;
          Button1.Visible = false;
      }
