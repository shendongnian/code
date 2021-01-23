    public class TextBoxViewModel : INotifyPropertyChanged
    {
        public TextBoxViewModel()
        {
            string label = _labelService.GetSpecificLabel(this, txtExample.Name).Label;
            this.text = label;
        }
        private string text;
        
        public string Text 
        { 
            get
            {
                return text;
            }
            set 
            {
                text = value;
                NotifyPropertyChanged("Text");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
