    public static class StringExtensions
    {
        public static string Left(this string s, int count)
        {
            // your method
            return "";
        }
        public static bool Contains(this string s, string contains, StringComparison comp)
        {
            // your method
            return true;
        }
    }
    public class Test
    {
        public static bool IsErrorMessage(String error)
        {
            var isErrorMessage = error.Left(40).Contains("ErrorMessage", StringComparison.CurrentCulture);
            return isErrorMessage;
        }
    }
