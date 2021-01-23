	// Writes the results of expressions like: "@foo.Bar"
	public virtual void Write(object value)
	{
		if (value is IHtmlString)
			WriteLiteral(value);
		else
			WriteLiteral(AntiXssEncoder.HtmlEncode(value.ToString(), false));
	}
	// Writes literals like markup: "<p>Foo</p>"
	public virtual void WriteLiteral(object value)
	{
		Buffer.Append(value);
	}
