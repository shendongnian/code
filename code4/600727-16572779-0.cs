    var child = new StubHttpContextBase();
    var basecontext=  new ShimHttpContextBase(child) 
        {
            UserGet= () =>   
                new GenericPrincipal(new GenericIdentity("mhu"), new string[0]) 
        };
    var conCntx = new ControllerContext();
    conCntx.HttpContext = basecontext;
    controllerUnderTest.ControllerContext = conCntx;
