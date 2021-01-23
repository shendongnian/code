    StringWriter stringWriter = new StringWriter();
    using (HtmlTextWriter tag = new HtmlTextWriter(stringWriter))
    {
        tag.AddAttribute(HtmlTextWriterAttribute.Href, string.Format("mailto:{0}", tenancyManager.UserEmail));
        tag.RenderBeginTag(HtmlTextWriterTag.A);
        tag.Write(tenancyManager.UserEmail);
        tag.RenderEndTag();
                        
    }
    literal.Text = stringWriter.ToString();
