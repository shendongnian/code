	private static void BuildHtml()
	{
		var content = new List<Content>
						{
							new Content() { RowKey= "1.0", Title = "Topic1" },
							new Content() { RowKey= "1.1", Title = "Some text for topic1" },
							new Content() { RowKey= "1.2", Title = "More text for topic1" },
							new Content() { RowKey= "2.0", Title = "Topic2 header" },
							new Content() { RowKey= "2.1", Title = "Some text for topic2" },
							new Content() { RowKey= "2.3", Title = "Some more text for topic2" }
								
						};
		var html = new XElement("Body", content
			.GroupBy(x => x.RowKey.Split('.').First())
			.Select(
				y =>
				new List<XElement>
					{
						new XElement("h2", y.First().RowKey.Split('.').First() + " " + y.First().Title,
										new XElement("ul", y.Skip(1).Select(z => new XElement("li", z.RowKey + " " + z.Title))))
					}));
		html.ToString();
	}
