    string messageIn;
    try
    {
       messageIn = Request.QueryString["msg"];
       // some code here
    }
    catch(Exception ex)
    {
      Response.Write(ex.Message);
    }
    if (!string.IsNullOrEmpty(messageIn)
    {
       string[] msg_arr = messageIn.Split(' ');
       ...
    }
