    using System;
    using Outlook = Microsoft.Office.Interop.Outlook;
    
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                Method1();
                Method2();
            }
    
            public static void Method1()
            {
                Outlook.Application outlookApp = new Outlook.Application();
                Outlook.MailItem mailItem = outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                mailItem.Subject = "This is the subject";
                mailItem.To = "john@example.com";
                string imageSrc = "D:\\Temp\\test.jpg"; // Change path as needed
    
                var attachments = mailItem.Attachments;
                var attachment = attachments.Add(imageSrc);
                attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x370E001F", "image/jpeg");
                attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001F", "myident"); // Image identifier found in the HTML code right after cid. Can be anything.
                mailItem.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/id/{00062008-0000-0000-C000-000000000046}/8514000B", true);
    
                // Set body format to HTML
    
                mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
                string msgHTMLBody = "<html><head></head><body>Hello,<br><br>This is a working example of embedding an image unsing C#:<br><br><img align=\"baseline\" border=\"1\" hspace=\"0\" src=\"cid:myident\" width=\"\" 600=\"\" hold=\" /> \"></img><br><br>Regards,<br>Tarik Hoshan</body></html>";
                mailItem.HTMLBody = msgHTMLBody;
                mailItem.Send();
            }
    
            public static void Method2()
            {
    
                // Create the Outlook application.
                Outlook.Application outlookApp = new Outlook.Application();
    
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
    
                //Add an attachment.
                String attachmentDisplayName = "MyAttachment";
    
                // Attach the file to be embedded
                string imageSrc = "D:\\Temp\\test.jpg"; // Change path as needed
    
                Outlook.Attachment oAttach = mailItem.Attachments.Add(imageSrc, Outlook.OlAttachmentType.olByValue, null, attachmentDisplayName);
    
                mailItem.Subject = "Sending an embedded image";
    
                string imageContentid = "someimage.jpg"; // Content ID can be anything. It is referenced in the HTML body
    
                oAttach.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001E", imageContentid);
    
                mailItem.HTMLBody = String.Format(
                    "<body>Hello,<br><br>This is an example of an embedded image:<br><br><img src=\"cid:{0}\"><br><br>Regards,<br>Tarik</body>",
                    imageContentid);
    
                // Add recipient
                Outlook.Recipient recipient = mailItem.Recipients.Add("john@example.com");
                recipient.Resolve();
    
                // Send.
                mailItem.Send();
            }
        }
    }
