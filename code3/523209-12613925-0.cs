        private void SetPartnerTemplate()
            {
                var sb = new StringBuilder();
                widget.RenderControl(new HtmlTextWriter(new StringWriter(sb)));
                string setting = sb.ToString();
                string fileLoc = @"D:\sample1.txt";
                FileStream fs = null;
                if (!File.Exists(fileLoc))
                {
                    using (fs = File.Create(fileLoc))
                    {
                    }
                }
                if (File.Exists(fileLoc))
                {
                    using (StreamWriter sw = new StreamWriter(fileLoc))
                    {
                        sw.Write(setting);
                    }
                }
                if (File.Exists(fileLoc))
                {
                    setting = File.ReadAllText(fileLoc);
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('File not found');</script>");
                }
                //after writing storing dat file to db
                //VoCServiceObj.SpSetWidgetRatingPartnerTemplate(setting, partnerid, productid);
            }
