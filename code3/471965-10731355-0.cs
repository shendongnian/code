	protected string formatException(Exception e)
	{
		Func<string, string> createFieldSet =
			t =>
				"<fieldset><legend><a href='#'>" +
				"<span class='show-expanded'>collapse message</span>" +
				"<span class='show-collapsed'>expand message</span>" +
				"</a></legend><p>" + t + "</p></fieldset>";
				
		var exError = new StringBuilder("<form>");
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		while (e != null)
		{
			exError.AppendLine(createFieldSet(e.Message));
			exError.AppendLine(createFieldSet(e.StackTrace));
			e = e.InnerException;
		}
		exError.AppendLine("</form>");
		return exError.ToString();
	}
