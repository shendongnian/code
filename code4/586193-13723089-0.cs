    System.Net.Mail.MailMessage Mensaje = new System.Net.Mail.MailMessage("mail@host.com",DireccionCorreo);
    System.Net.Mail.AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(Body, null, "text/html");
            
            
    System.Net.Mail.LinkedResource logo = new System.Net.Mail.LinkedResource("logoimage.jpg");
    logo.ContentId = "logoimage";
    htmlView.LinkedResources.Add(logo);
            
    System.Net.Mail.LinkedResource logoExchange = new System.Net.Mail.LinkedResource("logoexchange.png");
    logoExchange.ContentId = "logoexchange";
    htmlView.LinkedResources.Add(logoExchange);
            
    System.Net.Mail.LinkedResource tut1 = new System.Net.Mail.LinkedResource(Application.StartupPath + "/OutlookGuide/tut1.jpg");
    tut1 .ContentId = "tut1";
    htmlView.LinkedResources.Add(tut1 );
            
    System.Net.Mail.LinkedResource tut2 = new   System.Net.Mail.LinkedResource(Application.StartupPath + "/OutlookGuide/tut2.jpg");
    tut2.ContentId = "tut2";
    htmlView.LinkedResources.Add(tut2);
            
        
    Mensaje.AlternateViews.Add(htmlView);
        
             
