       string myXMLfile = Server.MapPath("XMLFile.xml");
          DataSet ds = new DataSet();
    // Create new FileStream with which to read the schema.
          System.IO.FileStream fsReadXml = new System.IO.FileStream(myXMLfile, System.IO.FileMode.Open);
          try
          {
              ds.ReadXml(fsReadXml);
              gridView1.DataSource = ds;
              gridView1.DataBind();
          }
          catch (Exception ex)
          {
               Response.Write(ex.Message);
          }
          finally
          {
              fsReadXml.Close();
          }
