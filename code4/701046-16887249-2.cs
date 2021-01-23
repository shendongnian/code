    public class Bar
    {
        private readonly IEnumerable<IFoo> _foos;
        public Bar(IEnumerable<IFoo> foos)
        {
            _foos = foos;
        }
    }
