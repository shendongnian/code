    List<BodyContent> bodies = new List<BodyContent>();
      foreach (AE.Net.Mail.Attachment item in mail.AlternateViews)
      {
        bodies.Add(new BodyContent
        {
          ContentType = item.ContentType,
          Body = item.Body
        });
      }
