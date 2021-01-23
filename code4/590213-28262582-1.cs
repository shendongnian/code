    public class TestBase : IUseFixture<OneTimeFixture<ApplicationFixture>>
    {
        protected ApplicationFixture Application;
    
        public void SetFixture(OneTimeFixture<ApplicationFixture> data)
        {
            this.Application = data.Current;
        }
    }
    
    public class ApplicationFixture : IDisposable
    {
        public ApplicationFixture()
        {
                // This code run only one time
        }
    
        public void Dispose()
        {
                // Here is run only one time too
        }
    }
    
    public class OneTimeFixture<TFixture> where TFixture : class, new()
    {
        public OneTimeFixture()
        {
            object fixture;
            if (!OneTimeFixtureStorage.Fixtures.TryGetValue(typeof(TFixture), out fixture))
            {
                fixture = new TFixture();
                OneTimeFixtureStorage.Fixtures.Add(typeof(TFixture), fixture);
    
                var disposable = fixture as IDisposable;
                if (disposable != null)
                {
                    AppDomain.CurrentDomain.DomainUnload += (sender, args) => disposable.Dispose();
                }
            }
    
            this.Current = (TFixture)fixture;
        }
    
        public TFixture Current { get; private set; }
    }
    
    internal class OneTimeFixtureStorage
    {
        internal static readonly Dictionary<Type, object> Fixtures;
    
        static OneTimeFixtureStorage()
        {
            Fixtures = new Dictionary<Type, object>();
        }
    }
