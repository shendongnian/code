    public class MyClass
    {
        private IDataProvider dataProvider;
        public void MyMethod()
        {
            try
            {
                this.dataProvider.GetData();
            }
            catch (OutOfMemoryException)
            {
            }
        }
    }
