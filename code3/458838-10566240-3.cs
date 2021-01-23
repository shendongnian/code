	public static class ITemplateExtensions
	{
		public static string Run(this ITemplate template)
		{
			ExecuteContext context = new ExecuteContext();
			string result = template.Run(context);
			return result;
		}
	}
