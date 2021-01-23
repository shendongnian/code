    public class MyViewModel : INotifyPropertyChanged
    {
       private MyObj _customerObj;
       public MyObj CustomerObj
       {
           get { return _customerObj;}
           set
            {
                if (_customerObj != value)
                {
                    _customerObj = value;
                    
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("CustomerObj"));
                    }
                }
            }
       }
    }
