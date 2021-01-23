    public class ChangeUIStateMessage
    {
        public bool UILocked { get; private set; }
 
        public ChangeUIStateMessage(bool uiLocked)
        {
            UILocked = uiLocked;
        }
    }
