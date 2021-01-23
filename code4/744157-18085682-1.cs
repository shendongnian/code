    public class ViewModel : INotifyPropertyChanged
	{
		private bool _isResetingColumns;
		public bool IsResetingColumns
		{
			get
			{
				return _isResetingColumns;
			}
			set
			{
				if (_isResetingColumns == value)
					return;
				_isResetingColumns = value;
				OnPropertyChanged("IsResetingColumns");
			}
		}
        private void OnResourceCultureCollectionChanged(object sender,
                                                        ResourceCulturesCollectionChangedEventArgs e)
        {
            //VIEWMODEL IS SETTING THIS TO TRUE BEFORE RESETTING `RESOURCES`
            IsResetingColumns = true;
            Resources.Clear();
            foreach (var rvm in e.NewResourceCollection.Select(r => new ResourceViewModel(r)).ToList())
                Resources.Add(rvm);
            //VIEW'S LISTENING TO THIS PROPERTY CHANGED (naming could be better, or an event ,but the gist is there)
            IsResetingColumns = false;
        }
    
