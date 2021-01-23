    public delegate void Action<T>(T value);
    public class GenericDelegate
    {
        static void Perform<T>(Action<T> act, params T[] arr)
        {
            for (int i = 0; i < arr.Count(); i++)
            {
                act(arr[i]);
            }
        }
    }
