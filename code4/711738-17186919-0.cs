    public void Email(string htmlBody, string emailSubject) {
      var mailMessage = new MailMessage("from@company.com", "to@company.com");
      mailMessage.IsBodyHtml = true;
      mailMessage.SubjectEncoding = Encoding.UTF8;
      mailMessage.BodyEncoding = Encoding.UTF8;
      mailMessage.Body = htmlBody;
      mailMessage.Subject = emailSubject;
      // embedd images
      var imageUrls = new List<EmailImage>();
      var regexImg = new Regex(@"<img[^>]+>", RegexOptions.IgnoreCase);
      var regexSrc = new Regex(@"src=[""](?<url>[^""]+)[""]", RegexOptions.IgnoreCase);
      mailMessage.Body = regexImg.Replace(mailMessage.Body, (matchImg) => {
        var value = regexSrc.Replace(matchImg.Value, (matchSrc) => {
          string url = matchSrc.Groups["url"].Value;
          var image = imageUrls.Where(i => string.Compare(i.Url, url, StringComparison.OrdinalIgnoreCase) == 0).FirstOrDefault();
          if (image == null) {
            image = new EmailImage { Url = url, MailID = Convert.ToString(imageUrls.Count) };
            imageUrls.Add(image);
          }
          return string.Format(@"src=""cid:{0}""", image.MailID);
        });
        return value;
      });
      if (imageUrls.Count > 0) {
        var htmlView = AlternateView.CreateAlternateViewFromString(mailMessage.Body, null, "text/html");
        for (int i = 0; i < imageUrls.Count; i++) {
          var request = WebRequest.Create(imageUrls[i].Url);
          var response = (HttpWebResponse)request.GetResponse();
          var stream = response.GetResponseStream();
          var memoryStream = new MemoryStream((int)response.ContentLength);
          CopyStream(stream, memoryStream);
          memoryStream.Seek(0, SeekOrigin.Begin);
          var imageLink = new LinkedResource(memoryStream, GetContentType(response.ContentType, imageUrls[i].Url));
          imageLink.ContentId = imageUrls[i].MailID;
          imageLink.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
          htmlView.LinkedResources.Add(imageLink);
        }
        mailMessage.AlternateViews.Add(htmlView);
      }
      SmtpClient.Send(mailMessage);
    }
