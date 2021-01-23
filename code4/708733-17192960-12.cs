    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Threading;
    namespace WpfApplication11
    {
    	public class FeedViewModel : INotifyPropertyChanged
    	{
    		public event PropertyChangedEventHandler PropertyChanged = delegate {};
    		DispatcherTimer timer =
                            new DispatcherTimer(DispatcherPriority.Background);
    		private string feedName;
    		public string FeedName
    		{
    			get { return feedName; }
    			set
    			{
    				feedName = value;
    				PropertyChanged(this,
                                        new PropertyChangedEventArgs("FeedName"));
    				PropertyChanged(this,
                                        new PropertyChangedEventArgs("FeedTitle"));
    			}
    		}
    		public ObservableCollection<ItemViewModel> FeedItems { get; set; }
    		public string FeedTitle
    		{
    			get
    			{
    				return string.Format("({0}/{1}) {2}",
    						FeedItems.Count(item => item.IsSynchronized),
    						FeedItems.Count,
                            FeedName);
    			}
    		}
    		public FeedViewModel()
    		{
    			FeedItems = new ObservableCollection<ItemViewModel>();
    			timer.Interval = TimeSpan.FromMilliseconds(1000);
    			timer.Tick += (sender, args) =>
    				    PropertyChanged(this,
                                       new PropertyChangedEventArgs("FeedTitle"));
    			timer.Start();
    		}
    	}
    }
