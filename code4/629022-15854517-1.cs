    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MyViewModel()
        {
            collection = new ObservableCollection<myClass>(new[]
            {
                new myClass{ text = "some more test - some more test - some more test - some more test - some more test - some more test - some more test - some more test - some more test - " },
                new myClass{ text = "test me test me = test me test me = test me test me = test me test me = test me test me = test me test me = " },
                new myClass{ text = "test again - test again - test again - test again - test again - " },
                new myClass{ text = "test again - test again - " },
                new myClass{ text = "test again - " },
                new myClass{ text = "test" },
            });
            mc = new myClass();
        }
        public ObservableCollection<myClass> collection { get; set; }
        public myClass mc { get; set; }
    }
    public class myClass
    {
        public string text { get; set; }
        AvalonRelayCommand _copyCommand;
        public AvalonRelayCommand CopyCommand
        { get { return _copyCommand ?? (_copyCommand = new AvalonRelayCommand(ApplicationCommands.Copy) { Text = "My Copy" }); } }
        AvalonRelayCommand _pasteCommand;
        public AvalonRelayCommand PasteCommand
        { get { return _pasteCommand ?? (_pasteCommand = new AvalonRelayCommand(ApplicationCommands.Paste) { Text = "My Paste" }); } }
        AvalonRelayCommand _cutCommand;
        public AvalonRelayCommand CutCommand
        { get { return _cutCommand ?? (_cutCommand = new AvalonRelayCommand(ApplicationCommands.Cut) { Text = "My Cut" }); } }
        AvalonRelayCommand _undoCommand;
        public AvalonRelayCommand UndoCommand
        { get { return _undoCommand ?? (_undoCommand = new AvalonRelayCommand(ApplicationCommands.Undo) { Text = "My Undo" }); } }
        AvalonRelayCommand _redoCommand;
        public AvalonRelayCommand RedoCommand
        { get { return _redoCommand ?? (_redoCommand = new AvalonRelayCommand(ApplicationCommands.Redo) { Text = "My Redo" }); } }
    }
