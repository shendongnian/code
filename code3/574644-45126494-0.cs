    public class ExposedClassToTest : ClassToTest
    {
        public bool ExposedProtectedMethod(int parameter)
        {
            return base.ProtectedMethod(parameter);
        }
    }
