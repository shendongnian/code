    using System.ComponentModel;
    namespace WpfApplication11
    {
    	public class ItemViewModel : INotifyPropertyChanged
    	{
    		public event PropertyChangedEventHandler PropertyChanged = delegate {};
    		private string itemName;
    		private bool isSynchronized;
    		public string ItemName
    		{
    			get { return itemName; }
    			set
    			{
    				itemName = value;
    				PropertyChanged(this, new PropertyChangedEventArgs("ItemName"));
    			}
    		}
    		public bool IsSynchronized
    		{
    			get { return isSynchronized; }
    			set
    			{
    				isSynchronized = value;
    				PropertyChanged(this,
                                    new PropertyChangedEventArgs("IsSynchronized"));
    			}
    		}
    	}
    }
