    try
    {
        SMTPServer.Send(mailObj);
        // Clear email form
        Control1.Text = string.Empty;
        Control2.Text = string.Empty;
        // etc...
        MessageLbl.Text = "Email Sent SucessFully.";
    }
    catch (Exception ex)
    {
        MessageLbl.Text = ex.ToString();
    }
