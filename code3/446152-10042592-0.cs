    // or you ILease interface if a parent class will not contain any shared logic
    abstract class Lease
    {
        public abstract void Lease();
        // example of shared logic
        protected void Save(Lease l) { }
    }
    
    class PrivateLease : Lease
    {
        public override void Lease() { // private logic here }
    }
    
    class BusinessLease : Lease
    {
        public override void Lease() { // business logic here }
    }
    
    Leas l = ...
    l.Lease(); // exec the logic
