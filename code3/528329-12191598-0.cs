    public class MainModelView : INotifyPropertyChanged
    {
    	public MainModelView()
    	{
    		var coll = new ObservableCollection<YourClass>();
    		yourCollView = CollectionViewSource.GetDefaultView(coll);
    		yourCollView.Filter += new Predicate<object>(yourCollView_Filter);
    	}
    
    	bool yourCollView_Filter(object obj)
    	{
    		return FilterItems
    			? false // now filter your item
    			: true;
    	}
    	
    	private ICollectionView yourCollView;
    	public ICollectionView YourCollView
    	{
    		get { return yourCollView; }
    		set
    		{
    			if (value == yourCollView) {
    				return;
    			}
    			yourCollView = value;
    			this.NotifyPropertyChanged("YourCollView");
    		}
    	}
    
    	private bool _filterItems;
    	public bool FilterItems
    	{
    		get { return _filterItems; }
    		set
    		{
    			if (value == _filterItems) {
    				return;
    			}
    			_filterItems = value;
    			// filer your collection here
    			YourCollView.Refresh();
    			this.NotifyPropertyChanged("FilterItems");
    		}
    	}
    	
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	private void NotifyPropertyChanged(String propertyName)
    	{
    		var eh = PropertyChanged;
    		if (eh != null) {
    			eh(this, new PropertyChangedEventArgs(propertyName));
    		}
    	}
    }
