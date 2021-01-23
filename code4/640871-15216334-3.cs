    public class ClassTwo : ISomeInterface
    {
        private ISomeInterface _MyPrivateReusableComponent = new ClassOne();
        public void ShowMessage()
        {
           _MyPrivateReusableComponent.ShowMessage()
        }
    
        public void DisplayPlace()
        {
             _MyPrivateReusableComponent.DisplayMessage()
            //implementation
        }
    }
