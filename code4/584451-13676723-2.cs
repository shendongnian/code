    if(!IsPostBack)
    {
     string MyXmlFile= @"E:\\Programming stuff\\Work\\website\\XMLFile.xml";    
     using(System.IO.FileStream MyReadXml=new System.IO.File.OpenRead(MyXmlFile))
      {
        DataSet ds= new DataSet();
        ds.ReadXml(MyReadXml);
        //Add DataGrid control markup in .aspx.
        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();
      }
     }
