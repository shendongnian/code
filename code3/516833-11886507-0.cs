		BindingList<Foo> _allFoos;
		private void LoadData(IEnumerable<Foo> dataToDisplayInGrid)
		{
			this._allFoos = new BindingList<Foo>(dataToDisplayInGrid.ToList());
			this.FilterGridData(string.Empty);
		}
		private void FilterGridData(string filterText)
		{
			BindingList<Foo> filteredList = null;
			if (!string.IsNullOrEmpty(filterText))
			{
				string lowerCaseFilterText = filterText.ToLower();
				IList<Foo> filteredItems = this._allFoos.Where(x => (x.Name ?? string.Empty).ToLower().Contains(lowerCaseFilterText)).ToList();
				filteredList = new BindingList<Foo>(filteredItems);
			}
			else
			{
				filteredList = new BindingList<Foo>(this._allFoos);
			}
			dataGrid.DataSource = filteredList;
		}
