    public partial class Form1 : Form
		{
			public Form1()
			{
				InitializeComponent();
			}
			static void smtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
			{
				var state = e.UserState;
				//"Done"
			}
			private void Form1_Load(object sender, EventArgs e)
			{
				var smtpClient = new SmtpClient("smtp.gmail.com", 587)
				{
					EnableSsl = true,
					DeliveryMethod = SmtpDeliveryMethod.Network,
					UseDefaultCredentials = false,
					Credentials = new NetworkCredential("myEmail@gmail.com", "mypassword")
				};
				var message = new MailMessage("myEmail@gmail.com", "myEmail@gmail.com", "Subject", "body");
				smtpClient.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);
				smtpClient.SendAsync(message, new object());
				
			}
		}
