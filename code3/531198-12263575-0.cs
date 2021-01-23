    public class TextBoxAndCommandPresenter : INotifyPropertyChanged
    {
        private readonly Action<TextBoxAndCommandPresenter> _action;
        public TextBoxAndCommandPresenter(string description,
                                          Action<TextBoxAndCommandPresenter> action)
        {
            Description = description;
            _action = action;
        }
        public string Description { get; private set; }
        public string Value { get; set; }
        public ICommand Command
        {
            get { return new DelegateCommand(() => _action(this)); }
        }
    }
