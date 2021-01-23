    public class ViewModel : ViewModelBase
    {
        public ViewModel()
        {
            this.turnIsSelectedOnCommand = new RelayCommand(() => IsSelected = true);
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
        public Boolean IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }
        private Boolean isSelected;
        public RelayCommand TurnIsSelectedOnCommand
        {
            get { return turnIsSelectedOnCommand; }
        }
        private readonly RelayCommand turnIsSelectedOnCommand;
    }
