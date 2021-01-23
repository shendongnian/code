    public class SystemUnderTest
    {
        public SystemUnderTest(Func<IMyClass> c)
        {
            try
            {
                var c1 = c();
                // ...
            }
            catch (Exception)
            {
                var c2 = c();
                // ...
            }
        }
    }
