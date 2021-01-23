		using System.Text;
		using System.Web.Optimization;
		public sealed class InjectContentItemTransform : IItemTransform
		{
			private readonly string _beforeContent;
			private readonly string _afterContent;
			public InjectContentItemTransform(string beforeContent, string afterContent)
			{
				_beforeContent = beforeContent ?? string.Empty;
				_afterContent = afterContent ?? string.Empty;
			}
			public string Process(string includedVirtualPath, string input)
			{
				if (_beforeContent.Length == 0 && _afterContent.Length == 0)
				{
					return input;
				}
				var contentBuilder = new StringBuilder();
				if (_beforeContent.Length > 0)
				{
					contentBuilder.AppendLine(_beforeContent);
				}
				contentBuilder.AppendLine(input);
				if (_afterContent.Length > 0)
				{
					contentBuilder.AppendLine(_afterContent);
				}
				return contentBuilder.ToString();
			}
		}
		
