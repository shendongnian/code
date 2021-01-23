    public abstract class ViewModelBase: INotifyPropertyChanged
    {
        public ICommand HelpCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName="")
        {
            var p = PropertyChanged;
            if (p != null)
            {
                p(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
