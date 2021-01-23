        public class  GenericTypeTest<T>
        {
            T value;
        }
        void MakeTest()
        {
            var newType = typeof(double);
            var customType = typeof(GenericTypeTest<object>).GetGenericTypeDefinition().MakeGenericType(newType);
            var createdObject = Activator.CreateInstance(customType);
        }
