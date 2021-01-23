	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Net.Mail;
	using UnityEngine;
	//^Make sure to include UnityEngine if you will connect to other game objects
	//Extend ScriptableObject to use custom code 
	public class EmailHandler extends ScriptableObject
	{
		public void SendEmail()
		{
			try
			{
				MailMessage mail = new MailMessage();
				SmtpClient smtpC = new SmtpClient("smtp.gmail.com");
				//From address to send email
				mail.From = new MailAddress("From@gmail.com");
				//To address to send email
				mail.To.Add("To@gmail.com");
				mail.Body = "This is a test mail from C# program";
				mail.Subject = "TEST";
				smtpC.Port = 587;
				//Credentials for From address
				smtpC.Credentials =(System.Net.ICredentialsByHost) new System.Net.NetworkCredential("EmailID", "password");
				smtpC.EnableSsl = true;
				smtpC.Send(mail);
				//Change Console.Writeline to Debug.Log 
				Debug.Log ("Message sent successfully");
			}
			catch (Exception e)
			{
				Debug.Log(e.GetBaseException());
				//You don't need or use Console.ReadLine();
			}
		}  
	}
