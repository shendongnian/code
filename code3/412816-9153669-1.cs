    public class MainFormViewModel : INotifyPropertyChanged {
      private object syncObject = new object();
      
      private MainFormModel model;
      public virtual MainFormModel Model {
        get { return model; }
        set {
          bool changed = (model != value);
          if (changed && model != null) DeregisterModelEvents();
          model = value;
          if (changed) {
            OnPropertyChanged("Model");
            if (model != null) RegisterModelEvents();
          }
        }
      }
      
      private bool isCalculating;
      public bool IsCalculating {
        get { return isCalculating; }
        protected set {
          bool changed = (isCalculating != value);
          isCalculating = value;
          if (changed) OnPropertyChanged("IsCalculating");
        }
      }
          
      public ObservableCollection<string> Messages { get; private set; }
      public ObservableCollection<Exception> Exceptions { get; private set; }
      
      protected MainFormViewModel() {
        this.Messages = new ObservableCollection<string>();
        this.Exceptions = new ObservableCollection<string>();
      }
      
      public MainFormViewModel(MainFormModel model)
        : this() {
        Model = model;
      }
      
      protected virtual void RegisterModelEvents() {
        Model.NewMessage += new EventHandler<SomeEventArg>(Model_NewMessage);
        Model.ExceptionThrown += new EventHandler<OtherEventArg>(Model_ExceptionThrown);
      }
      
      protected virtual void DeregisterModelEvents() {
        Model.NewMessage -= new EventHandler<SomeEventArg>(Model_NewMessage);
        Model.ExceptionThrown -= new EventHandler<OtherEventArg>(Model_ExceptionThrown);
      }
      
      protected virtual void Model_NewMessage(object sender, SomeEventArg e) {
        Messages.Add(e.Message);
      }
      
      protected virtual void Model_ExceptionThrown(object sender, OtherEventArg e) {
        Exceptions.Add(e.Exception);
      }
      
      public virtual void ClearMessages() {
        lock (syncObject) {
          IsCalculating = true;
          try {
            Messages.Clear();
          } finally { IsCalculating = false; }
        }
      }
      
      public virtual void ClearExceptions() {
        lock (syncObject) {
          IsCalculating = true;
          try {
            Exceptions.Clear();
          } finally { IsCalculating = false; }
        }
      }
      
      public event PropertyChangedEventHandler PropertyChanged;
      protected virtual void OnPropetyChanged(string property) {
        var handler = PropertyChanged;
        if (handler != null) handler(this, new PropertyChangedEventArgs(property));
      }
    }
