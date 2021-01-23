    public class SortedObservableList<T> : List<T>, INotifyPropertyChanged, INotifyCollectionChanged where T : INotifyPropertyChanged, IComparable<T>
    {
    	public void Add(T item)
    	{
    		base.Add(item);
    		base.Sort();
    		this.OnPropertyChanged("Count");
    		this.OnPropertyChanged("Item[]");
    		this.OnCollectionChanged(NotifyCollectionChangedAction.Add, item);
    		item.PropertyChanged += InnerObjectChanged;
    	}
    
    	private void InnerObjectChanged(object sender, PropertyChangedEventArgs e)
    	{
    		base.Sort();
    	}
    
    	public bool Remove(T item)
    	{
    		item.PropertyChanged -= InnerObjectChanged;
    		bool result = base.Remove(item);
    		this.OnPropertyChanged("Count");
    		this.OnPropertyChanged("Item[]");
    		this.OnCollectionChanged(NotifyCollectionChangedAction.Remove, item);
    		return result;
    	}
    
    	protected virtual void OnPropertyChanged([CallerMemberName] String propertyName = "")
    	{
    		if (this.PropertyChanged != null)
    		{
    			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    		}
    	}
    
    	protected virtual void OnCollectionChanged(NotifyCollectionChangedAction action, object item)
    	{
    		if (this.CollectionChanged != null)
    		{
    			this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, item));
    		}
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    	public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
