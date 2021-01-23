       if (FileUpload1.HasFile)
        {
            OleDbConnection ole = new OleDbConnection();
            
           
            string s = Server.MapPath("../admin/ProductOptions");
            s = s + "\\" + FileUpload1.FileName;
            
            FileUpload1.PostedFile.SaveAs(s);
            string path = s;
            
             ole.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + path + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;IMEX=2;READONLY=FALSE;" + "\" ";
            
            OleDbCommand command = new OleDbCommand("select * from[SHEET1$]", ole);
           
            DataSet ds = new DataSet();
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            
            
            adapter.Fill(ds);
            DataTable dt = (DataTable)ds.Tables[0];
            DataTable dt2 = new DataTable("dt2");
            Session["dt"] = null;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string s2 = dt.Columns[i].ToString();
                s2 = s2.Replace("#", ".");
              
                string ProductName = s2.ToString();
                if (Session["dt"] == null)
               {
                    DataColumn dCol1 = new DataColumn(ProductName, typeof(System.String));
                   dt2.Columns.Add(dCol1);
                }
                        
            }
            for (int i = 0; i <dt.Rows.Count; i++)
            {
                dt2.Rows.Add();
                for (int x = 0; x <dt.Columns.Count; x++)
                {
                    
            dt2.Rows[i][x] = dt.Rows[i][x];
            
                }
            
            }
            System.IO.File.Delete(s);
            GridView1.DataSource = dt2;
            GridView1.DataBind();
            
            GridView1.Visible = true;
           string filepath = Server.MapPath("ProductOptions") + "\\" + DDLproduct.SelectedValue + ".xml";
           // Session["ss"] = ds;
           
            write_to_xml(dt2,filepath);
        }
        else
        {
            Label2.Visible = true;
           Label2.Text="[Please Select a file]";
        }
