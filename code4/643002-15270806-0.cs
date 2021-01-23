    var inlineLogo = new LinkedResource("path/myfile.png");
                                    inlineLogo.ContentId = Guid.NewGuid().ToString(); 
        
    var imageHtmlFragment = string.Format("<img alt='My Logo'  src='cid:{0}' style='width: 250px;height: 60px;'/>",inlineLogo.ContentId);
    
    var newMail = new MailMessage();
    
    var view = AlternateView.CreateAlternateViewFromString(imageHtmlFragment, null, "text/html");
                            view.LinkedResources.Add(inlineLogo);
                            newMail.AlternateViews.Add(view);
