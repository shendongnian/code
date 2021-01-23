    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            MailAddress from = new MailAddress("Someone@domain.topleveldomain", "Name and stuff");
            MailAddress to = new MailAddress("Someone@domain.topleveldomain", "Name and stuff");
            List<MailAddress> cc = new List<MailAddress>();
            cc.Add(new MailAddress("Someone@domain.topleveldomain", "Name and stuff"));
            SendEmail("Want to test this damn thing", from, to, cc);
        }
        protected void SendEmail(string _subject, MailAddress _from, MailAddress _to, List<MailAddress> _cc, List<MailAddress> _bcc = null)
        {
            string Text = "";
            SmtpClient mailClient = new SmtpClient("Mailhost");
            MailMessage msgMail;
            Text = "Stuff";
            msgMail = new MailMessage();
            msgMail.From = _from;
            msgMail.To.Add(_to);
            foreach (MailAddress addr in _cc)
            {
                msgMail.CC.Add(addr);
            }
            if (_bcc != null)
            {
                foreach (MailAddress addr in _bcc)
                {
                    msgMail.Bcc.Add(addr);
                }
            }
            msgMail.Subject = _subject;
            msgMail.Body = Text;
            msgMail.IsBodyHtml = true;
            mailClient.Send(msgMail);
            msgMail.Dispose();
        }
    }
