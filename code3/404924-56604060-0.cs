    class MyClass
    {
        public void MyMethod(Type targetType = null)
        {
            if(targetType == null)
            {
                targetType = typeof(MyClass);
            }
        }
    }
