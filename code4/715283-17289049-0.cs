               try
                {
                    string filename = Server.MapPath("~") + "/Blah" + "/Blah.xml";
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filename);    
                    XmlNodeList Email = doc.GetElementsByTagName("EmailTo");
                    dtrecord = (DataTable)ViewState["datatable"];
                    foreach (XmlNode node in Email)
                    {
                        XmlElement MailElement = (XmlElement)node;    
                        string User1 = CDBInteract.formatSQLInput(MailElement.GetElementsByTagName("User1")[0].InnerText);
                        string User2 = CDBInteract.formatSQLInput(MailElement.GetElementsByTagName("User2")[0].InnerText);
                        Sendemail(dtrecord, User1, User2);
                    }               
                    
                }
                catch (Exception ex)
                {
                }
           //Create a separate method for sending email
           private void Sendemail(DataTable dtrecord, string emailto, string bcc)
            {
                try
                {
                    Utils util = new Utils();
                    string Body = "";
                    if (dtrecord.Rows.Count > 0)
                    {
                        DataView dv = dtrecord.DefaultView;
                        dv.Sort = "FamNmae";
                        DataTable Dts = dv.ToTable();
                        string SUName = CDBInteract.formatInput(ReadConfigSettings.Get("SUName"));
                        string SUEmail = CDBInteract.formatInput(ReadConfigSettings.Get("SUEmail"));
                        string SmtpClient = CDBInteract.formatInput(ReadConfigSettings.Get("SmtpClient"));
                        string EmailTo = emailto;
                        string BCC = bcc;
                        int m = util.SendMail(SUName, SUEmail, EmailTo, BCC, SmtpClient, "Blah", Body);
    
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception();
                }
            }
