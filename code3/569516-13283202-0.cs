    public NoteViewModel : INotifyPropertyChanged
    {
      //Collection must be a property
      public ObservableCollection<Note> NotesList {get; private set;}
   
      public NoteViewModel()
      {
         //Initialize your collection in the constructor
         NotesList = new ObservableCollection<Note>()
      }
      //.
      //.
      //.
    }
