        StringBuilder htmlResponse = new StringBuilder();
        using (StringWriter sw = new StringWriter(htmlResponse))
        {
            using (HtmlTextWriter textWriter = new HtmlTextWriter(sw))
            {
                Control emailBody = Page.LoadControl("myEmailControl.ascx");
                emailBody.RenderControl(textWriter);
            }
        }
        string emailHtml = htmlResponse.ToString();
