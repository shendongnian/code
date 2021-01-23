    var req = (HttpWebRequest)WebRequest.Create(uri);
    if(lastMod.HasValue)
      req.IfModifiedSince = lastMod.Value;//note: must be UTC, use lastMod.Value.ToUniversalTime() if you store it somewhere that converts to localtime, like SQLServer does.
    if(eTag != null)
      req.AddHeader("If-None-Match", eTag);
    try
    {
      using(var rsp = (HttpWebResponse)req.GetResponse())
      {
        lastMod = rsp.LastModified;
        if(lastMod.Year == 1)//wasn't sent. We're just going to have to download the whole thing next time to be sure.
          lastMod = null;
        eTag = rsp.GetResponseHeader("ETag");//will be null if absent.
        using(var stm = rsp.GetResponseStream())
        {
          //your code to save the stream here.
        }
      }
    }
    catch(WebException we)
    {
      var hrsp = we.Response as HttpWebResponse;
      if(hrsp != null && hrsp.StatusCode == HttpStatusCode.NotModified)
      {
        //unfortunately, 304 when dealt with directly (rather than letting
        //the IE cache be used automatically), is treated as an error. Which is a bit of
        //a nuisance, but manageable. Note that if we weren't doing this manually,
        //304s would be disguised to look like 200s to our code.
    
        //update these, because possibly only one of them was the same.
        lastMod = hrsp.LastModified;
        if(lastMod.Year == 1)//wasn't sent.
          lastMod = null;
        eTag = hrsp.GetResponseHeader("ETag");//will be null if absent.
      }
      else //some other exception happened!
        throw; //or other handling of your choosing
    }
    
