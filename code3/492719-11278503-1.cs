    public class MyData : INotifyPropertyChanged
    {
       private string myDataProperty;
       public MyData()
       {
           myDataProperty = "I like to be a label text!";
       }
       public string MyDataProperty
       {
          get { return myDataProperty; }
          set
          {
            myDataProperty = value;
            OnPropertyChanged("MyDataProperty");
          }
       }
       public event PropertyChangedEventHandler PropertyChanged;
       private void OnPropertyChanged(string info)
       {
          PropertyChangedEventHandler handler = PropertyChanged;
          if (handler != null)
          {
            handler(this, new PropertyChangedEventArgs(info));
          }
       }
    }
