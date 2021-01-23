    public class Node : ViewModelBase
    {
        public String Text
        {
            get { return text; }
            set
            {
                if (text != value)
                {
                    text = value;
                    OnPropertyChanged("Text");
                }
            }
        }
        private String text;
    
        public ObservableCollection<Node> Nodes { get; set; }
    }
    
