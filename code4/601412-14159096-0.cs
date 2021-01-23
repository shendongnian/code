	public class MyLayoutListener : Java.Lang.Object, ViewTreeObserver.IOnGlobalLayoutListener
    {
        public void OnGlobalLayout()
        {
            // do stuff here
        }
    }
    vto.AddOnGlobalLayoutListener(new MyLayoutListener());
