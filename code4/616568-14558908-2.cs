    Application app = new Application();
    Package package = null;
    package = app.LoadPackage(deployed ssis package path,null) //Load DTSX path
    //Access the SSIS variables
    pkg.Connections["sConn"].ConnectionString = strSourceConn;
    pkg.Connection["dConn"].ConnectionString = strDestConn;
