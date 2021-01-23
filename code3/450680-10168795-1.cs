    private void Form1_Load(object sender, EventArgs e)
    {
        count = 0;
        timer = new Timer();
        timer.Interval = 1000;
        timer.Tick += new EventHandler(timer1_Tick);
        timer.Start();
        List<string> s1 = System.IO.Directory.GetFiles(@"F:\gdimaging\data", "*.*", SearchOption.AllDirectories).ToList<string>();
        s1.AddRange(System.IO.Directory.GetFiles(@"F:\hios\DATA", "*.*", SearchOption.AllDirectories).ToList<string>());
        s1.AddRange(System.IO.Directory.GetFiles(@"F:\imgviewer\data", "*.*", SearchOption.AllDirectories).ToList<string>());
        s1.AddRange(System.IO.Directory.GetFiles(@"F:\newcnas\data", "*.*", SearchOption.AllDirectories).ToList<string>());
        s1.AddRange(System.IO.Directory.GetFiles(@"F:\newpod\data", "*.*", SearchOption.AllDirectories).ToList<string>());
        s1.AddRange(System.IO.Directory.GetFiles(@"F:\OMS\data", "*.*", SearchOption.AllDirectories).ToList<string>());
        s1.AddRange(System.IO.Directory.GetFiles(@"F:\WEBIMG", "*.*", SearchOption.AllDirectories).ToList<string>());
        //s1 = Directory.GetFiles(@"F:\gdimaging\data", "*.*");
        dt.Columns.Add("File_Name");
        dt.Columns.Add("File_Type");
        dt.Columns.Add("File_Size");
        dt.Columns.Add("Create_Date");
		// new mail list class
		class mailList {
		public bool isEmpty = true;
		MailMessage mailMessage;
		// do all the onceonly stuff in the constructor
			public mailList(){
				mailMessage = new MailMessage();
        		mailMessage.To.Add(new MailAddress("shahrul1509@yahoo.com"));
        		mailMessage.To.Add(new MailAddress("shahrul_kakashi90@hotmail.com"));
        // set subject
        		mailMessage.Subject = "FILE SIZE WARNING MESSAGE";
		        // Identify the credentials to login to the gmail account  
		        string sendEmailsFrom = "shahrul1509@gmail.com";
                        // password below is written in * to encrypt it
		        string sendEmailsFromPassword = "***4556**";
		        NetworkCredential cred = new NetworkCredential(sendEmailsFrom, sendEmailsFromPassword);
		        SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);
		        mailClient.EnableSsl = true;
		        mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
		        mailClient.UseDefaultCredentials = false;
		        mailClient.Timeout = 20000;
		        mailClient.Credentials = cred;
		        mailMessage.IsBodyHtml = true;
		        mailMessage.From = new MailAddress("shahrul1509@gmail.com", "Shahrul Nizam");
		
			}
			public addFile(String fileName){
				mailMessage.Body = mailMessage.Body + sysInfo.Name+ "HAS REACH ITS SIZE LIMIT.";
				isEmpty = false;
			}
			public send(){
	        	mailClient.Send(mailMessage);
	        	MessageBox.Show("Email Notification Sent!");
			}
		}
		
		}
        try
        	{
			mailList ml = new mailList();
        	foreach(string s in s1)
        		{
                	FileInfo info = new FileInfo(s);
                	FileSystemInfo sysInfo = new FileInfo(s);
                	dr = dt.NewRow();
                //System.Collections.Generic.List<string> nameList;
                	dr["File_Name"] = sysInfo.Name;
                	dr["File_Type"] = sysInfo.Extension;
                	dr["File_Size"] = (info.Length / 1024).ToString();
                	dr["Create_Date"] = sysInfo.CreationTime.Date.ToString("dd/MM/yyyy");
                	dt.Rows.Add(dr);
                	if ((info.Length / 1024) > 1500000)
                	{
                    	ml.addFile(sysInfo.Name);
                		if (dt.Rows.Count > 0)
                		{
                    	dataGridView1.DataSource = dt;
                		}
        			}
					if(ml.isEmpty==false){
						ml.Send();
					}
        		}
        catch (UnauthorizedAccessException ex)
        {
            MessageBox.Show("Error : " + ex.Message);
            continue;
        }
    }
