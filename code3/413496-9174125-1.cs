    try
    {
       WebResponse response;
       FailureMessagebox.ShowIfFailure(() => response = webRequest.GetResponse());
    }
    catch (WebException err)
    {
       //handle the exception here.
    }
  
