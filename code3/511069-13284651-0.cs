            Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(HttpContext.Request.ApplicationPath);
            System.Net.Configuration.MailSettingsSectionGroup settings = (System.Net.Configuration.MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");
            System.Net.Configuration.SmtpSection smtp = settings.Smtp;
            System.Net.Configuration.SmtpNetworkElement network = smtp.Network;
            Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();
            MailItem mailItem = (MailItem)outlookApp.CreateItem(OlItemType.olMailItem);
            mailItem.To = network.TargetName;
            Attachment attachment = mailItem.Attachments.Add(
            "C://test.bmp"
            , OlAttachmentType.olEmbeddeditem
            , null
            , "test image"
            );
            string imageCid = "test.bmp@123";
            attachment.PropertyAccessor.SetProperty(
                "http://schemas.microsoft.com/mapi/proptag/0x3712001E"
                , imageCid
                );
            mailItem.BodyFormat = OlBodyFormat.olFormatRichText;
            mailItem.HTMLBody = String.Format(
                  "<body><img src=\"cid:{0}\"></body>"
                 , imageCid
                 );
            
            mailItem.Importance = OlImportance.olImportanceNormal;
            mailItem.Display(false);
