    public class Thing
    {
        public int ThreadSafeMethod(string parameter1)
        {
            int number;
            number = this.GetLength(parameter1);
            return number;
        }
    
        private int GetLength(string value)
        {
            int length = value.Length;
            return length;
        }
    }
