    [ContentProperty("Content")]
    public class ModelForMyListBox : INotifyPropertyChanged
    {
        private string title;
        private object content;
        public string Title
        {
            get { return title; }
            set
            {
                if (value == title)
                    return;
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public object Content
        {
            get { return content; }
            set
            {
                if (value == content)
                    return;
                content = value;
                OnPropertyChanged("Content");
            }
        }
    }
