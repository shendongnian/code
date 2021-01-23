    public class Foo<T>   where T : class, new()
    {
        public T oneEmptyElement()
        {
            return new T();
        }
        public T setAttribute(string attributeName, string attributeValue)
        {
            T objT = new T();
            System.Reflection.FieldInfo fld = typeof(T).GetField(attributeName);
            if (fld != null)
            {
                fld.SetValue(objT, attributeValue);
            }
            return objT;
        }
        public List<T> listOfTwoEmptyElements()
        {
            List<T> aList = new List<T>();
            aList.Add(new T());
            aList.Add(new T());
            return aList;
        }
    }
