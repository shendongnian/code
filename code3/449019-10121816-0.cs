    List<Customer> customerList = GetAllCustomers();
    string subject = "Hello World";
    string content = GetContent();
    // Loop through all customers and send e-mail to each
    foreach(Customer customer in customerList)
    {
       MailMessage newMail = new MailMessage("you@yourcompany.com, customer.Email, subject, content);
    
       newMail.IsBodyHtml = true;
    
       SmtpClient sender = new SmtpClient();
    
       sender.Send(newMail);
    }
