    public interface IBar
    {
    	void SomeMethod(string param);
    }
    
    public class Bar : IBar
    {
        public void SomeMethod(string param) {}
    }
    
    public interface IBarRepository
    {
        List<IBar> GetBarsFromStore();
    }
    
    public class FooService
    {
        private readonly IBarRepository _barRepository;
    
        public FooService(IBarRepository barRepository)
        {
            _barRepository = barRepository;
        }
    
        public List<IBar> GetBars()
        {
            var bars = _barRepository.GetBarsFromStore();
            foreach (var bar in bars)
            {
                bar.SomeMethod("someValue");
            }
            return bars;
        }
    }
