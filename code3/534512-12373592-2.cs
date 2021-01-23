                if (SelectedFeatureLayer.ID == "AllAvailableFeatureLayer" || SelectedFeatureLayer.ID == "PMAvailableLayer")
            {
                if (msgToPM.Length != 0 & Regex.IsMatch(msgToPM, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    SLEmailMessage PMemailMessage = new SLEmailMessage
                    {
                        To = msgToPM,
                        From = "email@name.org",
                        CC = "email@name.org",
                        Bcc = "email@name.org",
                        Attachment = "location of attachment",
                        Subject = "Thanks to Bike Count Volunteers",
                        Body = PMmsgBody
                    };
                    emailClient.SendEmailAsync(PMemailMessage);
                }
    
