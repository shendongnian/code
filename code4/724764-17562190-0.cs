                string pid = Session["PatientID"].ToString();
                string strUploadPath = Server.MapPath("Files") + "\\" + pid + "\\";
                if (!System.IO.Directory.Exists(strUploadPath))
                {
                    System.IO.Directory.CreateDirectory(strUploadPath);
                }
                fuSample.SaveAs(strUploadPath + fuSample.FileName);
                lblMessage.Text = "File Successfully Uploaded";
