       public class MainWindowViewModel : ViewModelBase
       {
        public ViewModel1 ViewModel1 { get; set; }
        public ViewModel2 ViewModel2 { get; set; }
        public ViewModel3 Model3 { get; set; }
    
        public MainWindowViewModel()
        {
            ViewModel1 = new ViewModel1();
            ViewModel2 = new ViewModel2();
            ViewModel3 = new ViewModel3();
            ViewModel1.PropertyChanged += (s,e) => 
            {
               if(e.PropertyName == "IsBusy") 
               { 
                  // set the MainWindowViewModel.IsBusy property here
                  // for example:
                  IsBusy = ViewModel1.IsBusy;
               }
             }
        //IsBusy = true; - its working
       }
    }
