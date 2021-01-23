    System.Net.Mail.LinkedResource theContent = new System.Net.Mail.LinkedResource({path to image});
    theContent.ContentID = "TheContent";
    
    String altViewString = anEmail.Body.replace("{original imageSource i.e. '../Images/someimage.gif'}","cid:TheContent");
    
    System.Net.Mail.AlternateView altView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(altViewString, Nothing, System.Net.Mime.MediaTypeNames.Text.Html);
    
    altView.LinkedResources.add(theContent);
    
    anEmail.Message.AlternateViews.Add(altView);
