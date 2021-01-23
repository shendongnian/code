    public interface IFactory<T>
    {
        T Create();
    }
    
    public class SystemUnderTest
    {
        public SystemUnderTest(IFactory<IMyClass> factory)
        {
            try
            {
                var c1 = factory.Create();
                // ...
            }
            catch (Exception)
            {
                var c2 = factory.Create();
                // ...
            }
        }
    }
