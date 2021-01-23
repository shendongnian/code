    public class Thing
    {
        public int ThreadSafeMethod(string parameter1)
        {
            int number; // each thread will have its own variable for number.
            number = parameter1.Length;
            return number;
        }
    }
