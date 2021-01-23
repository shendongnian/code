    public class TheThing
    {
        private readonly ISummator _summator;
        public TheThing(ISummator summator)
        {
            _summator = summator;
        }
        public void SomeMethod()
        {
            _summator.SumStuff();
        }
    }
