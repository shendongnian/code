	listViewItems = (
			from p in problems
			select new
				{
					Key = p.Key,
					Value = from i in p.Value.Items
							select new ListViewItem
									{
										Token = i.Token,
										IsFatalError = i.IsFatal,
										Checked = false,
										Line = i.Token.Position.Line,
										Description = i.Description,
										BackgroundBrush = i.IsFatal 
															? Brushes.Red 
															: null
									}
				}
		).ToDictionary(x => x.Key, x => x.Value);
