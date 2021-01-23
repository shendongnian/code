    public class MyModel : INotifyPropertyChanged
    {
      string fullAnswer;
     
      public event PropertyChangedEventHandler PropertyChanged;
 
      public string FullAnswer
      {
        get { return fullAnswer; }
        set
        {
          if(string.Equals(value, fullAnswer)) return; // skip for equal values
         
          fullAnswer = value;
          OnPropertyChanged("FullAnswer");
          OnPropertyChanged("Answer1");
          OnPropertyChanged("Answer2");
        }
      }
      public string Answer1
      {
        get { return fullAnswer.Split('.')[0]; }
      }
      public string Answer2
      {
        get { return fullAnswer.Split('.')[1]; }
      }
      protected void OnPropertyChanged(string propertyName)
      {
        var handler = this.PropertyChanged;
        
        if(handler != null)
          handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }
