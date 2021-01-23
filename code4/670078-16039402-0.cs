     [ComVisible(true)]
    [__DynamicallyInvokable]
    [Serializable]
    public class EventArgs
    {
        [__DynamicallyInvokable]
        public static readonly EventArgs Empty = new EventArgs();
        static EventArgs()
        {
        }
        [__DynamicallyInvokable]
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public EventArgs()
        {
        }
    }
