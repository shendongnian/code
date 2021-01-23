    public class ViewModel : ViewModelBase
    {
        public ViewModel()
        {
            this.text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            this.backspaceCommand = new RelayCommand(
                () => Text = Text.Substring(0, Text.Length - 1), 
                () => !String.IsNullOrEmpty(Text));
        }
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
        public RelayCommand BackspaceCommand
        {
            get { return backspaceCommand; }
        }
        private readonly RelayCommand backspaceCommand;
    }
