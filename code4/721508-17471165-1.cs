    	public class IRCUser : IComparable<IRCUser>, INotifyPropertyChanged
    	{
    		private string _nick;
    		public string Nick
    		{
    			get
    			{
    				return _nick;
    			}
    			set
    			{
    				if (value != _nick)
    				{
    					...
    					OnPropertyChanged();
    				}
    			}
    		}
    
    		public int CompareTo(IRCUser other)
    		{
    ...
    		}
    
    
    		private void OnPropertyChanged([CallerMemberName] String propertyName = "")
    		{
    			if (PropertyChanged != null)
    			{
    				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    			}
    		}
    
    		public event PropertyChangedEventHandler PropertyChanged;
    	}
