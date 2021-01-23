        AlternateView body = AlternateView.CreateAlternateViewFromString(m_msg.Body,null,"text/html");
        //create the LinkedResource (embedded image)
        LinkedResource embimg= new LinkedResource(filename,System.Net.Mime.MediaTypeNames.Image.Jpeg);
        logo.ContentId = cid; // content-id used in image tag
        body.LinkedResources.Add(embimg);
        m_msg.AlternateViews.Add(body);
