    public class DataGrid
	{
		ObservableCollection<BaseColumn> columns = new ObservableCollection<BaseColumn>();
		public DataGrid()
		{
			columns.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(subClasses_CollectionChanged);
		}
		void subClasses_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			int count = columns.Count(x => x is DescriptionColumn);
			if (count > 1)
			{
				throw new CustomDataGridException("You can only have one description column");
			}
			if (count == 1)
			{
				if (!(columns[columns.Count - 1] is DescriptionColumn))
					throw new CustomDataGridException("Description column must be last");
			}
		}
		public ObservableCollection<BaseColumn> Columns
		{
			get
			{
				return columns;
			}
			set
			{
				if(columns != null)
					columns.CollectionChanged -= subClasses_CollectionChanged;
				columns = value;
				if (columns != null)
					columns.CollectionChanged += subClasses_CollectionChanged;
			}
		}
	}
