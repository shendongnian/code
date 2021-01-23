        public class  GenericTypeTest<T>
        {
            public GenericTypeTest(T value)
            {
                this.value = value;
            }
            public T value {get; protected set; }
        }
        public void ShowSomething<T>(GenericTypeTest<T> genericContainer)
        {
             MessageBox.Show(genericContainer.value.ToString());
        }
        void MakeTest()
        {
            var newType = typeof(double); object newValue = 1.0;
            var customType = typeof(GenericTypeTest<object>).GetGenericTypeDefinition().MakeGenericType(newType);
            var createdObject = Activator.CreateInstance(customType, newValue);
            this.GetType().GetMethod("ShowSomething").MakeGenericMethod(newType).Invoke(this, new object[] { createdObject });
        }
