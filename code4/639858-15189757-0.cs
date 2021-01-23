    public class MyConvert
    {
        public static int ToInt32(string input)
        {
            return String.IsNullOrEmpty(input) ? 0 : Convert.ToInt32(input);
        }
    }
