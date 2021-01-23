    private MailMessage report = new MailMessage();
    ...
    if (this.report.IsBodyHtml)
    {
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(this.bodyText.ToString(), this.report.BodyEncoding, "text/html");
                
                LinkedResource headerImageLink = new LinkedResource(ConfigReader.GetConfigValue("ImageLocation") + "\\MyBanner.gif", "image/gif");
                headerImageLink.ContentId = "headerImageId";
                headerImageLink.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
                LinkedResource footerImageLink = new LinkedResource(ConfigReader.GetConfigValue("ImageLocation") + "\\horizontal_c.gif", "image/gif");
                footerImageLink.ContentId = "footerImageId";
                footerImageLink.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
                
                htmlView.LinkedResources.Add(headerImageLink);
                htmlView.LinkedResources.Add(footerImageLink);
                this.report.AlternateViews.Add(htmlView);
    }
