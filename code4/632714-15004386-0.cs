	listViewItems = problems.ToDictionary(
		p => p.Key,
		p => new ObservableCollection<ListViewItem>(
			p.Value.Items.Select(
				i => new ListViewItem
					{
						Token = i.Token,
						IsFatalError = i.IsFatal,
						Checked = false,
						Line = i.Token.Position.Line,
						Description = i.Description,
						BackgroundBrush = i.IsFatal ? Brushes.Red : null
					}
				)
			)
		);
