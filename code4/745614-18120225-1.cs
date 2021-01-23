    class MyCodeSnippet:INOtifyPropertyChanged
    {
       public object MyProperty {
         get; 
         set
          {
            //Register for Notification
          }
        }
       
       //Implement all the INotifyPropertyChanged function
    }
   
    valuebinding.Path = new PropertyPath("MYProperty");
    valuebinding.Source = MyClass;
