    public class MyViewModel : BaseViewModel
    {
    
        public bool CountLabelVisible
        {
            get { return _countLabelVisible; }
            set { SetProperty(ref value, ref _countLabelVisible, true, "CountLabelVisible", "CountLabelVisibleReverse "); }
        }
    
        public bool CountLabelVisibleReverse { get { return !_countLabelVisible; }}
    
    }
