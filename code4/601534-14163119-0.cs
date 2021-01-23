    public class Foo<T>
    {
        T[] buffer;
        public void Stuff()
        {
            var type = typeof(T);
            if (type == typeof(int[]))
            {
                ...
            }
            else if (type == typeof(double[]))
            {
                ...
            }
        }
    }
