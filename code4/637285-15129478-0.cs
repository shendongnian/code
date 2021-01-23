    interface IA<T> where T : IB
    {
        ICollection<T> Bs { get; set; }
    }
    interface IB
    {
    }
    public class BBase : IB
    {
    }
    public class ABase : IA<BBase>
    {
        public ICollection<BBase> Bs { get; set; }
    }
