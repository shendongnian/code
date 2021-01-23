    using System.Collections.ObjectModel;
    namespace WpfApplication11
    {
    	public class DataSet
    	{
    		public ObservableCollection<FeedViewModel> Feeds { get; private set; }
    		public DataSet()
    		{
    			Feeds = new ObservableCollection<FeedViewModel>
    			{
    				new FeedViewModel
    				{
    					FeedName = "Feed #1",
    					FeedItems = new ObservableCollection<ItemViewModel>
    					{
    						new ItemViewModel
    						{
    							ItemName = "Item #1.1",
    							IsSynchronized = true
    						},
    						new ItemViewModel
    						{
    							ItemName = "Item #1.2",
    							IsSynchronized = true
    						},
    						new ItemViewModel
    						{
    							ItemName = "Item #1.3",
    							IsSynchronized = false
    						},
    					}
    				},
    				new FeedViewModel
    				{
    					FeedName = "Feed #2",
    					FeedItems = new ObservableCollection<ItemViewModel>
    					{
    						new ItemViewModel
    						{
    							ItemName = "Item #2.1",
    							IsSynchronized = true
    						},
    						new ItemViewModel
    						{
    							ItemName = "Item #2.2",
    							IsSynchronized = true
    						},
    					}
    				},
    				new FeedViewModel
    				{
    					FeedName = "Feed #3",
    					FeedItems = new ObservableCollection<ItemViewModel>
    					{
    						new ItemViewModel
    						{
    							ItemName = "Item #3.1",
    							IsSynchronized = false
    						},
    						new ItemViewModel
    						{
    							ItemName = "Item #3.2",
    							IsSynchronized = false
    						},
    					}
    				}
    			};
    		}
    	}
    	public class DataSetCreator
    	{
    		public DataSet CreateDataSet()
    		{
    			return new DataSet();
    		}
    	}
    }
