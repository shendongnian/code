    A proposed solution will be:   
    protected void Button1_Click(object sender, EventArgs e)
    {
            try
            {
                CreateXMLFile();
              
          
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("bulk_in", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@account_det", sw_XmlString.ToString ());
           int i= cmd.ExecuteNonQuery();
                if(i>0)
                {
                    Label1.Text = "File Upload successfully";
                }
                else
                {
                    Label1.Text = "File Upload unsuccessfully";
                    return;
                }
   
            con.Close();
                }
            catch(SqlException ex)
            {
                Label1.Text = ex.Message.ToString();
            }
        }
         public void CreateXMLFile()
            {
              try
                {
                    M_Filepath = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                    fileExtn = Path.GetExtension(M_Filepath);
                    strGuid = System.Guid.NewGuid().ToString();
                    fNameArray = M_Filepath.Split('.');
                    fName = fNameArray[0];
                           
                    xlRptName = fName + "_" + strGuid + "_" + DateTime.Now.ToShortDateString ().Replace ('/','-');
                     fileName =  xlRptName.Trim()  + fileExtn.Trim() ;
                     FileUpload1.PostedFile.SaveAs(ConfigurationManager.AppSettings["ImportFilePath"]+ fileName);
                    strFileName = Path.GetFileName(FileUpload1.PostedFile.FileName).ToUpper() ;
                    if (((strFileName) != "DEMO.XLS") && ((strFileName) != "DEMO.XLSX"))
                    {
                        Label1.Text = "Excel File Must be DEMO.XLS or DEMO.XLSX";
                    }
                   FileUpload1.PostedFile.SaveAs(System.Configuration.ConfigurationManager.AppSettings["ImportFilePath"] + fileName);
                   lstrFilePath = System.Configuration.ConfigurationManager.AppSettings["ImportFilePath"] + fileName;
                   if (strFileName == "DEMO.XLS")
                    {
                        
                        strConn = "Provider=Microsoft.JET.OLEDB.4.0;" + "Data Source=" + lstrFilePath + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
                    } 
                    if (strFileName == "DEMO.XLSX")
                    {
                        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + lstrFilePath + ";" + "Extended Properties='Excel 12.0;HDR=YES;'";
                    }
                    strSQL = " Select [Name],[Mobile_num],[Account_number],[Amount],[date_a2] FROM [Sheet1$]";
                 
                    OleDbDataAdapter mydata = new OleDbDataAdapter(strSQL, strConn);
                    mydata.TableMappings.Add("Table", "arul");
                    mydata.Fill(dsExcl);
                    dsExcl.DataSetName = "DocumentElement";
                    intRowCnt = dsExcl.Tables[0].Rows.Count;
                    intColCnt = dsExcl.Tables[0].Rows.Count;
                    if(intRowCnt <1)
                    {
                        Label1.Text = "No records in Excel File";
                        return;
                    }
                    if  (dsExcl==null)
                    {
                    }
                    else
                        if(dsExcl.Tables[0].Rows.Count >= 1000 )
                        {
                            Label1.Text = "Excel data must be in less than 1000  ";
                        }
                   
                    for (intCtr = 0; intCtr <= dsExcl.Tables[0].Rows.Count - 1; intCtr++)
                    {
                        if (Convert.IsDBNull(dsExcl.Tables[0].Rows[intCtr]["Name"]))
                        {
                            strValid = "";
                        }
                        else
                        {
                            strValid = dsExcl.Tables[0].Rows[intCtr]["Name"].ToString();
                        }
                        if (strValid == "")
                        {
                            Label1.Text = "Name should not be empty";
                            return;
                        }
                        else
                        {
                            strValid = "";
                        }
                        if (Convert.IsDBNull(dsExcl.Tables[0].Rows[intCtr]["Mobile_num"]))
                        {
                            strValid = "";
                        }
                        else
                        {
                            strValid = dsExcl.Tables[0].Rows[intCtr]["Mobile_num"].ToString();
                        }
                        if (strValid == "")
                        {
                            Label1.Text = "Mobile_num should not be empty";
                        }
                        else
                        {
                            strValid = "";
                        }
                        if (Convert.IsDBNull(dsExcl.Tables[0].Rows[intCtr]["Account_number"]))
                        {
                            strValid = "";
                        }
                        else
                        {
                            strValid = dsExcl.Tables[0].Rows[intCtr]["Account_number"].ToString();
                        }
                        if (strValid == "")
                        {
                            Label1.Text = "Account_number should not be empty";
                        }
                        else
                        {
                            strValid = "";
                        }
                        if (Convert.IsDBNull(dsExcl.Tables[0].Rows[intCtr]["Amount"]))
                        {
                            strValid = "";
                        }
                        else
                        {
                            strValid = dsExcl.Tables[0].Rows[intCtr]["Amount"].ToString();
                        }
                        if (strValid == "")
                        {
                            Label1.Text = "Amount should not be empty";
                        }
                        else
                        {
                            strValid = "";
                        }
                        if (Convert.IsDBNull(dsExcl.Tables[0].Rows[intCtr]["date_a2"]))
                        {
                            strValid = "";
                        }
                        else
                        {
                            strValid = dsExcl.Tables[0].Rows[intCtr]["date_a2"].ToString();
                        }
                        if (strValid == "")
                        {
                            Label1.Text = "date_a2 should not be empty";
                        }
                        else
                        {
                            strValid = "";
                        }
                    }
             
                }
             catch 
                {
                                
                }
             try
             {
                 if(dsExcl.Tables[0].Rows.Count >0)
                 {
                   
                     dr = dsExcl.Tables[0].Rows[0];
                 }
                 dsExcl.Tables[0].TableName = "arul";
                 dsExcl.WriteXml(sw_XmlString, XmlWriteMode.IgnoreSchema);
             }
             catch
             {
             }
    }`enter code here`
