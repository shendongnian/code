    string MyXmlFile= @"E:\\Programming stuff\\Work\\website\\XMLFile.xml";    
         using(System.IO.FileStream MyReadXml=new System.IO.File.OpenRead(MyXmlFile))
          {
            DataSet ds= new DataSet();
            ds.ReadXml(MyReadXml);
            DataGrid DataGrid1=new DataGrid();
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
            PlaceHolder1.Controls.Add(DataGrid1);
          } 
