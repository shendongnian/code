    public abstract class Something {
    }
    internal class ImplBase : Something {
        protected void callMe(string s) {}
    }
    internal class RealImpl : ImplBase {
    }
