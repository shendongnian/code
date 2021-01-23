        var fromAddress = "mailfrom@yourdomain";
        // any address where the email will be sending
        var toAddress = "mailto@yourdomain";
        //Password of your mail address
        const string fromPassword = "******";
        // Passing the values and make a email formate to display
        string subject = TextBox1.Text.ToString();
        string body = "From: " + TextBox2.Text + "\n";
        body += "Email: " + TextBox3.Text + "\n";
        body += "Subject: " + TextBox4.Text + "\n";
        body += "Message: \n" + TextBox5.Text + "\n";
        // smtp settings
        var smtp = new System.Net.Mail.SmtpClient();
        {
            smtp.Host = "relay-hosting.secureserver.net";
    **//Warning Delete =>//smtp.Port = 80;**
    **//Warning Delete =>//smtp.EnableSsl = false;**
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            smtp.Timeout = 20000;
        }
        // Passing values to smtp object
        smtp.Send(fromAddress, toAddress, subject, body);
