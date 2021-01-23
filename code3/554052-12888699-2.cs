    public delegate void Action<T>(T value);
    public class GenericDelegate
    {
        static void Perform<T>(Action<T> act, params T[] arr)
        {
            foreach (T obj in arr)
            {
                act(obj);
            }
        }
    }
