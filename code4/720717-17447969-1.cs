    public class MyClass : INotifyPropertyChanged
    {
      public event PropertyChangedEventHandler PropertyChanged;
    
      private void OnPropertyChanged(string propertyName)
      {
          if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    
      private int _feedback = 0;
    
      public int Feedback
      {
          get { return _feedback; }
          set
          {
              if (_feedback == value) return;
              _feedback = value;
              OnPropertyChanged("Feedback");
          }
      }
    
      private RelayCommand _upVoteCmd;
    
      public ICommand UpVoteCmd
      {
          get
          {
              if (_upVoteCmd == null) _upVoteCmd = new RelayCommand(o => Feedback += 1);
              return _upVoteCmd;
          }
      }
    
      private RelayCommand _downVoteCmd;
    
      public ICommand DownVoteCmd
      {
          get
          {
              if (_downVoteCmd == null) _downVoteCmd = new RelayCommand(o => Feedback -= 1);
              return _downVoteCmd;
          }
      }
    
    }
