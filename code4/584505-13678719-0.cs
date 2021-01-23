			var xml = @"<ENTRY><AUTHOR>C. Qiao</AUTHOR>
                              <AUTHOR>R.Melhem</AUTHOR>
                              <TITLE>Reducing Communication </TITLE>
                              <DATE>1995</DATE>
                       </ENTRY>";
			var tokenizer = new Dictionary<string, Func<XElement, string>>();
			tokenizer["AUTHOR"] = new Func<XElement, string>((author) =>
			{
				var sb = new StringBuilder();
				author.Value.Replace(".", " . ").Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries)
					.ToList()
						.ForEach(e => sb.AppendFormat("{0}\t\t{1}\n", e, author.Name));
				if(author.ElementsAfterSelf("AUTHOR").Any())
				{
					sb.Append("and");
				}
				else
				{
					sb.Append(",");
				}
				return sb.ToString();
			});
			tokenizer["TITLE"] = new Func<XElement, string>((title) =>
			{
				var sb = new StringBuilder();
				sb.Append("\"\n");
				title.Value.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries)
					.ToList()
						.ForEach(e => sb.AppendFormat("{0}\t\t{1}\n", e, title.Name));
				sb.Append("\"\n,");
				return sb.ToString();
			});
			tokenizer["DATE"] = new Func<XElement, string>((date) =>
			{
				var sb = new StringBuilder();
				date.Value.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries)
					.ToList()
						.ForEach(e => sb.AppendFormat("{0}\t\t{1}\n", e, date.Name));
				sb.Append(".");
				return sb.ToString();
			});
			var elem = XElement.Parse(xml);
			elem.Descendants().ToList().ForEach(c => Console.Write("{0}\n", tokenizer[c.Name.LocalName.ToUpper()](c)));	
