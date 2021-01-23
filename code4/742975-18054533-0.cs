    protected override void AddAttributesToRender(HtmlTextWriter writer)
    {
	base.AddAttributesToRender(writer);
	string text = this.ImageUrl;
	if (!this.UrlResolved)
	{
		text = base.ResolveClientUrl(text);
	}
	if (this.RenderingCompatibility >= VersionUtil.Framework45)
	{
		if (!string.IsNullOrEmpty(text) || base.DesignMode)
		{
			writer.AddAttribute(HtmlTextWriterAttribute.Src, text);
		}
	}
	else
	{
		if (text.Length > 0 || !base.EnableLegacyRendering)
		{
			writer.AddAttribute(HtmlTextWriterAttribute.Src, text);
		}
	}
        //...
