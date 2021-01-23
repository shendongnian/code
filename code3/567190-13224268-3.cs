    public class LoadMoreViewModel:BindableBase
    {
       public ICommand LoadMore{get;private set;}
       public LoadMoreViewModel(Action<object> action)
       {
         LoadMore = new DelegateCommand(action);
       }
    }
