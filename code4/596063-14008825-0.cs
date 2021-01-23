    public class HotKeyManager
    {
        public void RegisterKeySource(IKeySource source)
        {
            source.OnKeyPress += this.KeyPressHandler;
        }
        public void KeyPressHandler(object sender, KeyPressEventArgs args)
        {
            // ...
        }
        // ...
    }
    public interface IKeySource
    {
        event EventHandler<KeyPressEventArgs> OnKeyPress;
        // ...
    }
