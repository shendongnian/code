    public class DerivedClassToTestWrapper : DerivedClassToTest
    {
        public static Type_A MehodeToTestWrapped()
        {
            return DerivedClassToTest.MehodeToTest();
        }
    }
