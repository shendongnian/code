    StringBuilder htmlResponse = new StringBuilder();
    using (StringWriter sw = new StringWriter(htmlResponse))
    {
       using (HtmlTextWriter textWriter = new HtmlTextWriter(sw))
       {
          UserControl emailBody = new UserControl();
          emailBody.LoadControl("myEmailTemplate.ascx");
          emailBody.RenderControl(textWriter);
       }
    }
    string emailHtml = htmlResponse.ToString();
