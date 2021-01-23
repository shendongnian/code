	// Set the to and from addresses.
	// The from address must be your GMail account
	mail.From = new MailAddress("noreplyXYZ@gmail.com");
	mail.To.Add(new MailAddress(to));
	
	// Define the message
	mail.Subject = subject;
	mail.IsBodyHtml = isHtml;
	mail.Body = message;
	
	// Create a new Smpt Client using Google's servers
	var mailclient = new SmtpClient();
	mailclient.Host = "smtp.gmail.com";//ForGmail
	mailclient.Port = 587; //ForGmail
	
	
	// This is the critical part, you must enable SSL
	mailclient.EnableSsl = true;//ForGmail
	//mailclient.EnableSsl = false;
	mailclient.UseDefaultCredentials = true;
	
	// Specify your authentication details
	mailclient.Credentials = new System.Net.NetworkCredential("fromAddress@gmail.com", "xxxx123");//ForGmail
	mailclient.Send(mail);
	mailclient.Dispose();
