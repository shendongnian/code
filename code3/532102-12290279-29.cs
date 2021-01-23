    public class MyRow : INotifyPropertyChanged
    {
        // ...
    
        public string FormattedValue
        {
            get 
            {
               return string.Join( ", ", this.MyArray );
            }
         }
    }
