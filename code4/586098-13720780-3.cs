    public class MyViewModel : BaseViewModel
    {
        private bool _countLabelVisible;
        public bool CountLabelVisible
        {
            get { return _countLabelVisible; }
            set { SetProperty(ref value, ref _countLabelVisible, true, "CountLabelVisible", "CountLabelVisibleReverse"); }
        }
    
        public bool CountLabelVisibleReverse { get { return !_countLabelVisible; }} 
    }
