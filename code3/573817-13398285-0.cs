    public class Foo {
        public bool HistoricalMode { get; set; }
    	
    	private string _property1;
    	public string Property1 { 
    		get { 
    			if (HistoricalMode) {
    				return GetHistoricalValue("Property1");
    			} else {
    				return _property1;
    			}
    		set {
    			if (HistoricalMode){
    				throw new NotSupportedException("Updates not possible in historical mode.");
    			} else {
    				_property1 = value;
    			}
    		}
    	}
        public DateTime CreatedDate { 
    		get {
    			// Similar pattern as above
    		}
    		set {
    			// Similar pattern as above
    		}
    	}
    
        public string GetHistoricalValue(string propertyName) {
            HistoryHelper historyHelper = CreateHistoryHelper(this);
            return historyHelper.GetHistoricalValue(propertyName, CreatedDate);
        }
    }
