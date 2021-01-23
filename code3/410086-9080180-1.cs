    public abstract class BaseClass {
        public event EventHandler MyEvent;
    
        protected virtual void OnMyEvent(EventArgs e) {
            var local = MyEvent;
            if (local != null) local(this, e);
        }
    }
    
    public class DeriveClass : BaseClass {
        public void MyFunction() {
            OnMyEvent(null);
        }
    }
