    class MyViewModel:INotifyPropertyChanged
    {
         private ObservableColleciton<string> myCollection;
       public MyViewModel()
       {
          //FunctiontoFillCollection()
       }
       public ObservableColleciton<string> MyCollection
       {
             get { return myCollection;}
             set
             {
                 mycolletion = value;
                 // i am leaving implemenation of INotifyPropertyChanged on you 
                 // google it.. :)
                 OnpropertyChanged("MyCollection");
             }
       }
    }
