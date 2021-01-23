    public class ListBoxViewModel
    {
        private static readonly  List<string> sortList = new List<string>() { "Unsorted", "Sorted" };
        public List<string> SortList { get { return sortList; } }
        public ObservableCollection<ItemDetail> ItemDetails { get; set; }
		#region Up Command
		ICommand upCommand;
		public ICommand UpCommand
		{
			get
			{
				if (upCommand == null)
				{
					upCommand = new RelayCommand(UpExecute);
				}
				return upCommand;
			}
		}
		private void UpExecute(object param)
		{
			var id = param as ItemDetail;
			if (id != null)
			{
				var curIndex = ItemDetails.IndexOf(id);
				if (curIndex > 0)
					ItemDetails.Move(curIndex, curIndex - 1);
			}
		}
		#endregion Up Command
		#region Down Command
		ICommand downCommand;
		public ICommand DownCommand
		{
			get
			{
				if (downCommand == null)
				{
					downCommand = new RelayCommand(DownExecute);
				}
				return downCommand;
			}
		}
		private void DownExecute(object param)
		{
			var id = param as ItemDetail;
			if (id != null)
			{
				var curIndex = ItemDetails.IndexOf(id);
				if (curIndex < ItemDetails.Count-1)
					ItemDetails.Move(curIndex, curIndex + 1);
			}
		}
		#endregion Down Command
        public ListBoxViewModel()
        {
            ItemDetails = new ObservableCollection<ItemDetail>()
            {
                new ItemDetail() { IsSelected = false, ItemName = "Customer Id", SortOrder = "Unsorted" },
                new ItemDetail() { IsSelected = true, ItemName = "Customer Name", SortOrder = "Sorted" },
                new ItemDetail() { IsSelected = false, ItemName = "Customer Age", SortOrder = "Unsorted" }
            };
        }
    }
