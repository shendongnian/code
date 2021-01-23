    public class MagazineVM : IDataErrorInfo, INotifyPropertyChanged
    {
       private Magazine _magazine;
       
       public int FirstMagazineProperty
       {
          get { return _magazine.FirstMagazineProperty; }
          set { _magazine.FirstMagazineProperty = value; RaisePropertyChanged("FirstMagazineProperty"); }
       }
    
       //INotifyPropertyChanged implementation
    
       //IDataErrorInfo implementation
    }
