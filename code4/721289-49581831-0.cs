    SmtpClient smtp = new SmtpClient();
    smtp.EnableSsl = true;
    try
    {
        smtp.Send(mm);
    }
    catch (Exception ex)
    {
        MsgBox("Message not emailed: " + ex.ToString());
    }
