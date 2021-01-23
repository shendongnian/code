    public class MainViewModel
    	{
    		public MainViewModel()
    		{
    			Units = new ObservableCollection<UnitViewModel>();
    			Units.Add(new UnitViewModel
    			{
    				ID = "1",
    				Degrees = "80",
    				IsMaster = true
    			});
    			for (int i = 0; i < 10; i++)
    				Units.Add(new UnitViewModel
    				{
    					ID = "2",
    					Degrees = "40",
    					IsMaster = false
    				});
    		}
    
    		public ObservableCollection<UnitViewModel> Units {
    			get;
    			set;
    		}
    	}
    	
    
    	public struct UnitViewModel
    	{
    		public string ID { get; set;}
    		public string Degrees { get; set;}
    		public bool IsMaster { get; set;}
    
    	}
    }
