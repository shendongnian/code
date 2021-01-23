    public class Game 
    {
        public event EventHandler<SomeEventArgs> Update;
        protected virtual void OnUpdate(float mFrameTime) { // invoke event here }
    }
