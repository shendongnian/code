    internal interface IFlyable 
    {
        void Fly();
    }
    public class Bird: IFlyable 
    {
        public void Fly() { ... }
        void IFlyable.Fly() { ... }
    }
