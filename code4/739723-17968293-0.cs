    [ContentProperty("Bars")]
    public class FooControl : Control
    {
       private ObservableCollection<object> _bars = new ObservableCollection<object>();
       public ObservableCollection<object> Bars { get { return _bars; } }
    }
