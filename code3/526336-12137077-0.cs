    public class DieFactory
    {
        public DieFactory(IRandomProvider provider)
        {}
    
        public Die Create(int numberOfSides)
        {
            return new Die(numberOfSides, _provider);
        }
    }
