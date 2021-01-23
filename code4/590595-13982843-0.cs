		public class Article
		{
			public string Prop1 { get; set; }
			public string Prop2 { get; set; }
			public ArticleNewsItem ArticleNewsItem { get; set; }
		}
		public class ArticleDetailsViewModel
		{
			public string Prop1 { get; set; }
		}
		public class ArticleNewsItemDetailsViewModel : ArticleDetailsViewModel
		{
			public string Prop2 { get; set; }
			public string Prop3 { get; set; }
		}
		public class ArticleNewsItem
		{
			public string Prop3 { get; set; }
		}
