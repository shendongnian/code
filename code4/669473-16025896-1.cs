    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    public class StackOverFlowX : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StackOverFlowX()
        {
        }
        private ObservableCollection<string> contentWithListView;
        public ObservableCollection<string> ContentWithListView
        {
            get
            {
                return this.contentWithListView;
            }
            set
            {
                this.contentWithListView = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<int> stepNumber;
        public ObservableCollection<int> NumberStep
        {
            get
            {
                return this.stepNumber;
            }
            set
            {
                this.stepNumber = value;
                OnPropertyChanged();
            }
        }
        private int selectNumberStep;
        public int SelectNumberStep
        {
            get
            {
                return this.selectNumberStep;
            }
            set
            {
                this.selectNumberStep = value;
                OnPropertyChanged();
                OnPropertyChanged("Content");
            }
        }
        private string _content;
        public string Content
        {
            get
            {
                return contentWithListView[this.SelectNumberStep];
            }
            set
            {
                this._content = value;
                if (contentWithListView.IndexOf(value) > -1)
                {
                    SelectNumberStep = contentWithListView.IndexOf(value);
                    OnPropertyChanged("SelectNumberStep");
                }
                OnPropertyChanged();
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
