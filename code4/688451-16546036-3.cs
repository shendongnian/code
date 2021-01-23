    public class ShellViewModel : Screen
    {
         private object Child;
	
         public object Child
         {
               get{ return child; }
               set
               {
                    if(child == value)
                         return;
                    child = value;
                    NotifyOfPropertyChange(() => Child);
               }
         }
	
         public ShellViewModel()
         {
             this.Child = new MainViewModel();
         }
  
         public void ShowOtherView()
         {
               this.Child = new FooViewModel();
         }
    }
