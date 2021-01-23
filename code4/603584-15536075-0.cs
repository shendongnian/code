    public class MyUI
    {
        [DllImport("__Internal")]
        protected extern static void MyUIInit(IntPtr viewController);
        public MyUI(MonoTouch.UIKit.UIViewController viewController)
        {
            MyUIInit(viewController.Handle);
        }
    }
