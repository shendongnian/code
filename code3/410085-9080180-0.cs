    public abstract class BaseClass
    {
        public event EventHandler myEvent;
    
        protected void RaiseMyEvent(EventArgs e)
        {
            if (myEvent != null) myEvent(this, e)
        }
    }
    
    public class DeriveClass : BaseClass
    {
        public void MyFunction()
        {
            RaiseMyEvent(null);
        }
    }
