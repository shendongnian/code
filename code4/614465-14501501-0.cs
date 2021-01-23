    public interface IBlah
    {
        void Sum(IEnumerable<int> baz);
    }
    
    class Blah : IBlah
    {
        public void Sum(IEnumerable<int> baz)
        {
            return;
        }
    }
    
    public class Baz
    {
        private readonly IBlah blah;
    
        public Baz(IBlah blah)
        {
            this.blah = blah;
        }
    
        public void Sum(IEnumerable<int> baz)
        {
            blah.Sum(baz);
        }
    }
