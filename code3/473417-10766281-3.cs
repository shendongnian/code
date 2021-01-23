    public class MainViewModel : ViewModelBase
    {
    
      private bool isControlsEnabled;
      public bool IsControlsEnabled
      {
        get { return isControlsEnabled; }
        set
        {
          if (IsControlsEnabled.Equals(value)) return;
          isControlsEnabled = value;
          RaisePropertyChanged(() => IsControlsEnabled);
        }
        }
    }
