    //Declare these two variables global in the form, class
    MailMessage message;//= new MailMessage()
    SmtpClient smtpClient;//= new SmtpClient()
    
    //A function that will read data from CSV File into List and will create a     DataTable 
    public DataTable maketable()
        {
            string path = this.Server.MapPath("app_data");
            path += "\\employeelist.csv";
            List<string[]> testParse =
              parseCSV(path);
            DataTable newTable = new DataTable();
            foreach (string column in testParse[0])
            {
                newTable.Columns.Add();
            }
            foreach (string[] row in testParse)
            {
                newTable.Rows.Add(row);
            }
            return newTable;
        }
    //This Functions Actually reads the CSV file and make list
    public List<string[]> parseCSV(string path)
        {
            List<string[]> parsedData = new List<string[]>();
            try
            {
                using (StreamReader readFile = new StreamReader(path))
                {
                    string line;
                    string[] row;
                    while ((line = readFile.ReadLine()) != null)
                    {
                        row = line.Split(',');
                        parsedData.Add(row);
                    }
                }
            }
            catch (Exception e)
            {
                parent.list.Items.Add(e.Message);
            }
            return parsedData;
        }
   
    //I have called below function with given subject and body text as a string at any place.. either in button_click event or any other place
    SendAttendanceWithAttachment(email_subject, body);
    // Now the body of SendAttendanceWithAttachment(.....);
    void SendAttendanceWithAttachment(string subject, string body)
        {
            string FileAbsolutePath = "C:\\att\\"; // where the directory is containing files for attachment
            string FileName = "";
            Attachment attach;
            //OPen CSV File Read all contact and then send one by one. 
            smtpClient = new SmtpClient();
            smtpClient.Host = "<smtp host>";//like for google : ssl://smtp.gmail.com
            smtpClient.Port = <int>;// port number for google 465
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("<gmail address>", "<password>");
            
            MailAddress fromAddress = new MailAddress("<sender email address>");
            dt = maketable();
            try
            {
                add_item("Weekly attendance Sending starts....");
                for (int i = 0; i < dt.Rows.Count; i++)//dt.Rows.Count
                {
                    message = new MailMessage();
                    if (dt.Rows[i][1].ToString() == string.Empty)
                    {
                        continue;
                    }
                    else
                    {
                        FileName = FileAbsolutePath + dt.Rows[i][0].ToString() + ".csv";
                        if (File.Exists(FileName))
                        {
                            attach = new Attachment(FileName);
                            //Add in data
                            message.To.Add(dt.Rows[i][1].ToString());
                            message.Subject = subject;
                            message.IsBodyHtml = true;
                            message.Body = body;
                            message.From = fromAddress;
                            message.Attachments.Add(attach);
                            //add_item("Sending Message " + (i+1) + " of " + dt.Rows.Count + " to : " + dt.Rows[i][0].ToString());
                            SendMail(message, smtpClient);
                            //add_item("Email Sent to :" + dt.Rows[i][0].ToString());
                        }
                    }
                }
                //add_item("Weekly attendance Sent to all..");
            }
            catch (System.Exception e)
            {
                //parent.list.Items.Add(e.Message);
            }
    //Finally the SendMail()...
    public void SendMail(MailMessage message, SmtpClient smtpClient)
        {
            try
            {
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                //parent.list.Items.Add(ex.Message);
            }
        }
