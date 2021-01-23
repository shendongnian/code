    protected internal override void Render(HtmlTextWriter writer)
    {
        if (base.EnableLegacyRendering)
        {
            base.Render(writer);
        }
        else
        {
            writer.WriteBeginTag(this.TagName);
            this.RenderAttributes(writer);
            writer.Write(" />");
        }
    }
