    class MyObject
    {
        public string Text { get; set; }
    }
    class MyClass
    {
        private MyObject _myObject1 = new MyObject();
        private MyObject _myObject2 = new MyObject();
        private MyObject _myObject3 = new MyObject();
        public void Foo()
        {
            for (int i = 1; i < 4; i++)
            {
                // get the member of this type MyClass
                var member = GetType().GetMember("_myObject" + i, BindingFlags.Instance | BindingFlags.NonPublic);
                var fieldInfo = (FieldInfo)member[0];
                // get the value of the member info
                var field = fieldInfo.GetValue(this);
                // get the property to set
                var propertyInfo = field.GetType().GetProperty("Text");
                // set the value
                propertyInfo.SetValue(field, "my text", null);
            }
        }
    }
