    string strDevConnection = @"Data Source=DEVELOPMENT\SQLEXPRESS;Initial Catalog=sqlDB;Persist Security Info=True;User ID= ;Password= ";
    
    string strLiveConnection = @"Data Source=PRODUCTION\SQLEXPRESS;Initial Catalog=sqlDB;User id= ;password= ";
    
    Configuration myWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
    if (Request["connectionToUse"] + "" == "constr1")
    
    {
    
    myWebConfig.ConnectionStrings.ConnectionStrings["constr1"].ConnectionString = strDevConnection; //constr1 is the name of the current connectionstring in the web.config
    
    }
    
    else
    
    {
    
    myWebConfig.ConnectionStrings.ConnectionStrings["constr2"].ConnectionString = strLiveConnection;
    
    }
     myWebConfig.Save(); //Save the changes to web config
