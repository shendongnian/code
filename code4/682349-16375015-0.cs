            // first we create a plain text version and set it to the AlternateView
            // then we create the HTML version
            MailMessage msg = new MailMessage();
    
            msg.From = new MailAddress("from@email", "From Name");
            msg.Subject = "Subject";
            msg.To.Add("to@email");
            msg.BodyEncoding = Encoding.UTF8;
    
            String plainBody = "Body of plain email";
    
            //first we create the text version
            AlternateView plainView = AlternateView.CreateAlternateViewFromString(plainBody, Encoding.UTF8, "text/plain");
            msg.AlternateViews.Add(plainView);
    
            //now create the HTML version
            MailDefinition message = new MailDefinition();
            message.BodyFileName = "~/MailTemplates/template1.htm";
            message.IsBodyHtml = true;
            message.From = "from@email";
            message.Subject = "Subject";
    
            //Build replacement collection to replace fields in template1.htm file
            ListDictionary replacements = new ListDictionary();
            replacements.Add("<%USERNAME%>", "ToUsername");//example of dynamic content for Username
    
            //now create mail message using the mail definition object
            //the CreateMailMessage object takes a source control object as the last parameter,
            //if the object you are working with is webcontrol then you can just pass "this",
            //otherwise create a dummy control as below.
            MailMessage msgHtml = message.CreateMailMessage("to@email", replacements, new LiteralControl());
    
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(msgHtml.Body, Encoding.UTF8, "text/html");
    
    //example of a linked image        
            LinkedResource imgRes = new LinkedResource(Server.MapPath("~/MailTemplates/images/imgA.jpg"), System.Net.Mime.MediaTypeNames.Image.Jpeg);
            imgRes.ContentId = "imgA";
            imgRes.ContentType.Name = "imgA.jpg";
            imgRes.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
            htmlView.LinkedResources.Add(imgRes);
    
            msg.AlternateViews.Add(htmlView);
    
            //sending prepared email
            SmtpClient smtp = new SmtpClient();//It reads the SMPT params from Web.config
            smtp.Send(msg);
