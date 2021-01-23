    public class Element : INotifyPropertyChanged
    {
       private _IsSelected;
       public Boolean IsSelected 
       { 
          get { return _IsSelected; }
          set 
          { 
              _IsSelected = value; 
              if (PropertyChanged != null) 
                 PropertyChanged("IsSelected");
          }
       }    
    
       //snip Implement interface INotifyPropertyChanged.
 
       //snip your other code
    }
