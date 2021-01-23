    try
        {
         
            //Creating the Mail Message object.
            MailMessage Email=new MailMessage();
            //Storing the To value in the object reference.
            Email.To=txtTo;                
            //Storing the From value in the object reference.
            Email.From=txtFrom;
            //Storing the CC value in the object reference.
            Email.Cc=txtCC;
            //Storing the BCC value in the object reference.
            Email.Bcc=txtBCC;
            //Storing the Subject value in the object reference.
            Email.Subject=txtSubject;
            //Specifies the email body.
            Email.Body=txtMessage;
            //Setting priority to the mail as high,low,or normal
            Email.Priority=MailPriority.High;
            //Formatting the mail as html or text.
            Email.BodyFormat=MailFormat.Text;
            //Checking whether the attachment is needed or not.
            //if(rbtnAttach)
            //{
            //    //Adding attachment to the mail.
            //    Email.Attachments.Add(
            //        new MailAttachment(FileBrowse));
            //}
            //specifying the real SMTP Mail Server.
            SmtpMail.SmtpServer.Insert(0,"127.0.0.1");
            SmtpMail.Send(Email);//Sending the mail.
            //calling the reset method to erase all the data 
            //after sending the mail.
           
        }
        //Catching Exception 
        catch(Exception exc)
        { 
            
        }
