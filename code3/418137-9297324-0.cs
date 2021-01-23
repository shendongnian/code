    private static void SendActivationEmail(User user)
    {
        string activationLink = string.Concat("<a href='ht", "tp://mysite.com/", user.Username, "/", user.NewEmailKey, "'>Activate Here</a>");
        var message = new System.Net.Mail.MailMessage("email@email.com", user.Email)
        {
            Subject = "Activate your account",
            Body = activationLink,
            IsBodyHtml = true
        };
        var client = new System.Net.Mail.SmtpClient("smtp.email.com");
        client.Send(message);
    }
