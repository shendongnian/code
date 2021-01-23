    public class MessageParentBase
    {
    }
    public class ChatMessage : MessageParentBase
    {
    }
    public abstract class ParentMessageWindowBaseViewModel<T> where T : MessageParentBase
    {
        abstract internal ObservableCollection<T> GridData
        {
            get;
            set;
        }
    }
    public class Child : ParentMessageWindowBaseViewModel<ChatMessage>
    {
        internal override ObservableCollection<ChatMessage> GridData
        {
            get;
            set;
        }
    }
