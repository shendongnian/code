        public ICommand BrowseCommand {get; set;}
        public ICommand SearchCommand {get; set;}
        public ExampleViewModel()
        {
            this.BrowseCommand = new RelayCommand(new action<object>(MethodNameEnteredHere);
            this.SearchCommand = new RelayCommand(new action<object>(OtherMethodNameEnteredHere);
        }
