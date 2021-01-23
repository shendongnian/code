    try
    {
      ........
    }
    catch (WebException exception)
    {
       string responseText;
    
       using(var reader = new StreamReader(exception.Response.GetResponseStream()))
       {
         responseText = reader.ReadToEnd();
       }
    }
    catch (Exception ex)
    {
      ......
    }
