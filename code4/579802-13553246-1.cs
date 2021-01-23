    public class Builder<T>
        where T : new()
    {
        public static IList<T> CreateListOfSize(int size)
        {
            List<T> list = new List<T>();
            for (int i = 0; i < size; i++)
                list.Add(new T());
            return list;
        }
    }
