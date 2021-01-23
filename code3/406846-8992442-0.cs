    public class ZonesView : BaseViewModel
    {
       public ZonesView()
       {
          this.CheckAllZonesCommand = new DelegateCommand()
          {
             ExecuteMethod = new Action<object>(delegate(object o){ ((ZonesView)o).CheckAllZones(); }),
             CanExecuteMethod = new Func<bool>(delegate() { return true; })
           };
       }
    
        public ICommand CheckAllZonesCommand {get;private set;}
    }
