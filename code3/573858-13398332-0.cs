    public class PropertyUpdatedEventArgs: PropertyChangedEventArgs {
    	public PropertyUpdatedEventArgs(string propertyName, object oldValue, object newValue): base(propertyName) {
    		OldValue = oldValue;
    		NewValue = newValue;
    	}
    	
    	public object OldValue { get; private set; }
    	public object NewValue { get; private set; }
    }
    
    public interface INotifyPropertyUpdated {
    	event EventHandler<PropertyUpdatedEventArgs> PropertyUpdated;
    }
    
    public MyCustomClass: INotifyPropertyUpdated {
    	#region INotifyPropertyUpdated members
    	
    	public event EventHandler<PropertyUpdatedEventArgs> PropertyUpdated;
    	
    	private void OnPropertyUpdated (string propertyName, object oldValue, object newValue) {
    		var propertyUpdated = PropertyUpdated;
    		if (propertyUpdated != null) {
    			propertyUpdated(this, new PropertyUpdatedEventArgs(propertyName, oldValue, newValue));
    		}
    	}
    	
    	#endregion
    	#region Properties
    	
    	private int _someValue;
    	public int SomeValue {
    		get { return _someValue; }
    		set {
    			if (_someValue != value) {
    				var oldValue = _someValue;
    				_someValue = value;
    				OnPropertyUpdated("SomeValue", oldValue, SomeValue);
    			}
    		}
    	}
    	
    	#endregion	
    }
