    // or you ILease interface if a parent class will not contain any shared logic
    abstract class Lease
    {
        public abstract void Do();
        // example of shared logic
        protected void Save(Lease l) { }
    }
    
    class PrivateLease : Lease
    {
        public override void Do() { // private logic here }
    }
    
    class BusinessLease : Lease
    {
        public override void Do() { // business logic here }
    }
