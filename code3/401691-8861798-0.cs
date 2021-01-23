        var sb = new StringBuilder();
        var writer = new StringWriter(sb);
        var html = new Html32TextWriter(writer);
        html.RenderBeginTag(HtmlTextWriterTag.P);
        html.WriteEncodedText("paragraph1");
        html.RenderEndTag();
        ...
        ...
        html.Flush();
        var outputHtml = sb.ToString();
        placeHolder.Controls.Add(new LiteralControl(outputHtml));
