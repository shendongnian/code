    public interface INotifyMe<T>
    {
        T ResultToNotify { get; set; }
    }
    public class CreateServiceViewModel : ViewModelBase, INotifyMe<Member>
    {
        // ...
    }
    
    public class MemberSearchViewModel : ViewModelBase
    {
        public MemberSearchViewModel(INotifyMe<Member> toBeNotified)
        {
            // initialize field and so on...
        }
    }
