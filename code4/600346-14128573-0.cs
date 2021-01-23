    using (MailMessage mm = new MailMessage("...", "...", "Subject here", "Body here")) //Pick whatever constructor you want
    {
        using (Attachment a = new Attachment("c:\\test.ics", "text/calendar")) //Either load from disk or use a MemoryStream bound to the bytes of a String
        {
            a.Name = "meeting.ics";                         //Filename, possibly not required
            a.ContentDisposition.Inline = true;             //Mark as inline
            mm.Attachments.Add(a);                          //Add it to the message
            using (SmtpClient s = new SmtpClient("..."))    //Send using normal
            {
                s.Send(mm);
            }
        }
    }
