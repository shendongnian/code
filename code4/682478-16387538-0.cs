    public class ExternalDataService {
    	public EventHandler<DataChangedEventArgs> OnDataChanged;	
    }
    
    public class DataChangedEventArgs : EventArgs {
    	public Double Data {
    		get; set;
    	}
    }
    
    public class MyService {
     	private ExternalDataService _externalDataService;
        public MyService()
        {
            _externalDataService= new ExternalDataService ();
        }
        public IObservable<double> GetData()
        {
            return Observable.FromEventPattern<DataChangedEventArgs>(eh => _externalDataService.OnDataChanged += eh, eh => _externalDataService.OnDataChanged -= eh)
    			.Select(e => e.EventArgs.Data);
        }		
    }
