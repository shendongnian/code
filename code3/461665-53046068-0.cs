     protected void btnUpload_Click(object sender, EventArgs e)
        {
              if (Page.IsValid)
                {
                    bool logval = true;
                    if (logval == true)
                    {
                        String img_1 = fuUploadExcelName.PostedFile.FileName;
                        String img_2 = System.IO.Path.GetFileName(img_1);
                        string extn = System.IO.Path.GetExtension(img_1);
    
                        string frstfilenamepart = "";
                        frstfilenamepart = "Emp" + DateTime.Now.ToString("ddMMyyyyhhmmss"); ;
                        UploadExcelName.Value = frstfilenamepart + extn;
                        fuUploadExcelName.SaveAs(Server.MapPath("~/Emp/EmpExcel/") + "/" + UploadExcelName.Value);
                        string PathName = Server.MapPath("~/Emp/EmpExcel/") + "\\" + UploadExcelName.Value;
                        GetExcelSheetForEmp(PathName, UploadExcelName.Value);
                       
                    }
                }
           
            
        }
    
        private void GetExcelSheetForEmp(string PathName, string UploadExcelName)
        {
            string excelFile = "EmpExcel/" + PathName;
            OleDbConnection objConn = null;
            System.Data.DataTable dt = null;
            try
            {
    
                DataSet dss = new DataSet();
                String connString = "Provider=Microsoft.ACE.OLEDB.12.0;Persist Security Info=True;Extended Properties=Excel 12.0 Xml;Data Source=" + PathName;
                objConn = new OleDbConnection(connString);
                objConn.Open();
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                {
                    return;
                }
                String[] excelSheets = new String[dt.Rows.Count];
                int i = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (i == 0)
                    {
                        excelSheets[i] = row["TABLE_NAME"].ToString();
                        OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + excelSheets[i] + "]", objConn);
                        OleDbDataAdapter oleda = new OleDbDataAdapter();
                        oleda.SelectCommand = cmd;
                        oleda.Fill(dss, "TABLE");
    
                    }
                    i++;
                }
                grdByExcel.DataSource = dss.Tables[0].DefaultView;
                grdByExcel.DataBind();
                
               
            }
    
            catch (Exception ex)
            {
                ViewState["Fuletypeidlist"] = "0";
                grdByExcel.DataSource = null;
                grdByExcel.DataBind();
            }
            finally
            {
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
    
        }
