 static void Main(string[] args)
        {
            //create the mail message
            MailMessage mail = new MailMessage();
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("your.email@gmail.com", "yourpassword"),
                EnableSsl = true
            };
            
            //Console.WriteLine("Sent");
            //Console.ReadLine();
            //set the addresses
            mail.From = new MailAddress("your.email@gmail.com");
            mail.To.Add("to@wherever.com");
            //set the content
            mail.Subject = "Test subject!";
            mail.Body = "<html><body>your content</body></html>";
            mail.IsBodyHtml = true;
            client.Send(mail);
        }
