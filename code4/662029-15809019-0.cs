    class TypeDispatcher
    {
        private Dictionary<Type, Action<object>> _TypeDispatchers;
        public TypeDispatcher()
        {
            _TypeDispatchers = new Dictionary<Type, Action<object>>();
            // Add a method as lambda.
            _TypeDispatchers.Add(typeof(String), obj => Console.WriteLine((String)obj));
            // Add a method within the class.
            _TypeDispatchers.Add(typeof(int), MyInt32Action);
        }
        private void MyInt32Action(object value)
        {
            // We can safely cast it, cause the dictionary
            // ensures that we only get integers.
            var integer = (int)value;
            Console.WriteLine("Multiply by two: " + (integer * 2));
        }
        public void BringTheAction(object value)
        {
            Action<object> action;
            var valueType = value.GetType();
            // Check if we have something for this type to do.
            if (!_TypeDispatchers.TryGetValue(valueType, out action))
            {
                Console.WriteLine("Unknown type: " + valueType.FullName);
            }
            else
            {
                action(value);
            }
        }
