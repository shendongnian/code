    public abstract class Something {
    }
    internal class ImplBase : Something {
        private void callMe(string s) {}
        public void CallMe(string s) { this.callMe(s);}
    }
    internal class RealImpl : ImplBase {
    }
