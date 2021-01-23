      public Form1()
        {
            InitializeComponent();
        }
      SmtpClient smtpClient; 
      MailMessage message;
        /*...in your message initialization method*/
       message = new MailMessage();
       
       /*your block with message variable intializing, only without using*/
       message.From = new MailAddress(EmailFrom);
                recipients.ForEach(a => message.To.Add(new MailAddress(a)));
                message.Attachments.Add(new Attachment(LocationOfResults));
                message.Subject = String.Format("{0:MM-dd-yyyy} Results for task: ." +Desciption, DateTime.Now);
                message.Body = "Attached is the results file specified for the task: " ;
                smtpClient = new SmtpClient(); //initializing smtpClient variable
                smtpClient.SendCompleted  += new SendCompletedEventHandler(smtpClient_SendCompleted);
          /*so on*/
