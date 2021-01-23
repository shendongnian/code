    public class ClassTwo
    {
        private ISomeInterface _MyPrivateReusableComponent = new ClassOne();
        public abstract void ShowMessage()
        {
           _MyPrivateReusableComponent.ShowMessage()
        }
    
        public abstract void DisplayPlace()
        {
             _MyPrivateReusableComponent.DisplayMessage()
            //implementation
        }
    }
