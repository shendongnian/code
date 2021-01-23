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
        get
        {
          if(fullAnswer == null) return null;
          
          var tokens = fullAnswer.Split('.');
          if(tokens.Length < 1) return string.Empty;
          return tokens[0];
        }
      }
      public string Answer2
      {
        get
        {
          if(fullAnswer == null) return null;
          
          var tokens = fullAnswer.Split('.');
          if(tokens.Length < 2) return string.Empty;
          return tokens[1];
        }
      }
      protected void OnPropertyChanged(string propertyName)
      {
        var handler = this.PropertyChanged;
        
        if(handler != null)
          handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }
