	MailMessage _testMail = new MailMessage();
	_testMail.Body = "This is a test email";
	_testMail.To.Add(new MailAddress("email@domain.com"));
	_testMail.From = new MailAddress("sender@domain.com");
	_testMail.Subject = "Test email";
	_testMail.Save(@"c:\testemail.eml");
    var bytes = System.IO.File.ReadAllBytes(@"c:\testemail.eml");
    var bodyArray = System.Text.UnicodeEncoding.Unicode.GetBytes(bytes);
    var body = System.Convert.ToBase64String(bodyArray);    
