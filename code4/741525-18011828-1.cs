    class SomeThing<T>
    {
        public void Add(T value)
        {
            //...
        }
        public void Add(string value)
        {
            try
            {
                T typedValue;
                typedValue = (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(value);
                //Call Add with the converted value
                this.Add(typedValue);
            }
            catch
            {
                this.Add(default(T));
            }
        }
    }
