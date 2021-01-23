    using (TextWriter textWriter = new StringWriter())
    {
        using (HtmlTextWriter htmlWriter = new HtmlTextWriter(textWriter))
        {
            HtmlGenericControl control = new HtmlGenericControl("div");
            control.Attributes.Add("One", "1");
            control.Attributes.Add("Two", "2");
            control.InnerText = "Testing 123";
            control.RenderControl(htmlWriter);
        }
    }
