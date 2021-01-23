    public class SampleData : INotifyPropertyChanged
    {
      public SampleData ()
      {
         this.MyText = "myDef";
      }
      
      public string _myText;
      public string MyText
      {
        get { return _myText ; }
        set {
          _myText = value;
          this.RaisePropChanged("MyText");
        }
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      public void RaisePropChanged(string name) {
        var eh = this.PropertyChanged;
        if (eh != null) {
          eh(this, new PropertyChangedEventArgs(name));
        }
      }
    }
