    public void SmtpStream_Negotiate_EhloResultsCorrectly()
    {
        var ctx = new APIContext();
        var logger = new FakeLogger();
        var writer = new FakeStreamWriter();
        var reader = new FakeStreamReader { Line = "EHLO test.com" };
        var stream = new SmtpStream(logger, ctx, new MemoryStream())
        {
            _writer = writer,
            _reader = reader
        };
    
        Exception ex = null;
    
        try
        {
            stream.Negotiate(ctx);
        }
        catch (Exception x)
        {
            ex = x;
        }
    
        Assert.IsNull(ex);
        Assert.IsTrue(writer.Writes.ElementAt(0) == "250 Hello test.com");
        Assert.IsTrue(writer.Writes.ElementAt(1) == "250 STARTTLS");
    } 
   
