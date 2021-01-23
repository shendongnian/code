    public class Foo<T>   where T : class, new()
    {
        public T oneEmptyElement()
        {
            return new T();
        }
        public List<T> listOfTwoEmptyElements()
        {
            List<T> aList = new List<T>();
            aList.Add(new T());
            aList.Add(new T());
            return aList;
        }
    }
