    public sealed class MyClass: INotifyPropertyChanged
    {
       private static readonly MyClass instance = new MyClass();
       private MyClass() {}
    
       public static MyClass Instance
       {
          get 
          {
             return instance; 
          }
       }
       // notifying property
       private string privMyProp;
       public string MyProp
       {
           get { return this.privMyProp; }
           set
           {
               if (value != this.privMyProp)
               {
                   this.privMyProp = value;
                   NotifyPropertyChanged("MyProp");
               }
           }
       }
       
    
       // INotifyPropertyChanged implementation
       public event PropertyChangedEventHandler PropertyChanged;
       private void NotifyPropertyChanged(String info)
       {
           var handler = PropertyChanged;
           if (handler != null)
           {
               handler(this, new PropertyChangedEventArgs(info));
           }
       }
    }
