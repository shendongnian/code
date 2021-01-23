    public class BretListViewModel
    {
    
    	private void populateBret()
        {
            bretList = new ObservableCollection<BestServiceLibrary.bretItem>(BestClass.BestService.getBretList().ToList());
            bretList.CollectionChanged += bretList_CollectionChanged;              
        }
    
        void bretList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
             if (e.NewItems != null)
    		{
    			foreach (Object item in e.NewItems)
    			{
    				(item as INotifyPropertyChanged).PropertyChanged += new PropertyChangedEventHandler(item_PropertyChanged);
    			}
    		}
    		if (e.OldItems != null)
    		{
    			foreach (Object item in e.OldItems)
    			{
    				(item as INotifyPropertyChanged).PropertyChanged -= new PropertyChangedEventHandler(item_PropertyChanged);
    			}
    		}
        }
    	
    		
    	void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
    	{
    		var bret = sender as bretItem;
    		
    		//Update the database now!
    		
    		//One note:
    		//The ObservableCollection raises its change event as each item changes.
    		//You should consider a method of batching the changes (probably using an ICommand)
    	}
    	
    }
