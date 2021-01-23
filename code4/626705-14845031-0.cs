	interface ITriggers
	{
	}
	class CompletionTrigger : ITriggers
	{
	}
	interface ILanguage<T> where T: ITriggers
	{
		List<T> CompletionTriggers { get; set; }
	}
	
	class Language : ILanguage<CompletionTrigger>
	{
		public List<CompletionTrigger> CompletionTriggers { get; set; }
		public Language()
		{
			CompletionTriggers = new List<CompletionTrigger>();
		}
	}
