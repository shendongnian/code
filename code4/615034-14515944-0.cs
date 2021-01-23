    output.AddAttribute(HtmlTextWriterAttribute.Type, "text");
    if (!this.IsEnabled)
    {
        output.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
    }
    output.AddAttribute(HtmlTextWriterAttribute.Value, this.DisplayName);
    output.RenderBeginTag(HtmlTextWriterTag.Input);
    output.RenderEndTag();
