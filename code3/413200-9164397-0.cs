    MemoryStream msInput = new MemoryStream();
    var preCopyPosition = hlcContext.Request.InputStream.Position;
    
    hlcContext.Request.InputStream.CopyTo(msInput);
    byte[] byteInput = msInput.ToArray();
    
    // Go back to pre-copy state
    hlcContext.Request.InputStream.Position = preCopyPosition;
