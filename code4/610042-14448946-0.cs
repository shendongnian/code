    protected void MyObjDS_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
    {
    MyWebService.Service webProxy = new MyWebService.Service();
    webProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
    e.ObjectInstance = webProxy;
    }
