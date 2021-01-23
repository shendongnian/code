    public class MyObject : INotifyPropertyChanged
    {
         public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
         private object _data1;
        
         public object Data1
         {
           get{ return _data1;}
           set 
           { 
               _data1=value; 
               PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Data1"));
           }
         }
    }
