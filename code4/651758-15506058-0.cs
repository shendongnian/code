    public class MainWindowViewModel
    {
        private readonly IThing _thing = new Thing();
        public string MyText { get { return _thing.MyText; } }
    }
    public interface IThing
    {
        string MyText { get; }
    }
    public class Thing : INotifyPropertyChanged, IThing
    {
        private string _myText = "Testing 1 2 3";
        string IThing.MyText
        {
            get { return _myText; }
        }
        public string MyText
        {
            get { return _myText; }
            set
            {
            
                if (_myText != value)
                {
                    _myText = value;
                    OnPropertyChanged();
                }
            }
        }
        INotifyPropertyChanged
    }
