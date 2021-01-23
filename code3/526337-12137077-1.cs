    public class AGoodNameFactory
    {
        public DieFactory(IKernel kernel)
        {}
    
        public Die CreateDie(int numberOfSides)
        {
            var provider = _kernel.Resolve<IRandomProvider>();
            return new Die(numberOfSides, provider);
        }
        // other factories.
    }
