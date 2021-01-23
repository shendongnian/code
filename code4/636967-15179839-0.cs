    FiddlerApplication.BeforeResponse += delegate(Fiddler.Session oSession)
    {
        oSession.utilDecodeResponse();
        String oBody = System.Text.Encoding.UTF8.GetString(oSession.responseBodyBytes);
        oBody = oBody.Replace("<body>", "<body><script src='a.js' type='text/javascript'/>");
        oSession.utilSetResponseBody(oBody);
    };
