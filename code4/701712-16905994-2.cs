    public class MyProgram
    {
        public MyProgram()
        {
            string path = "Some Directory/Some SubDirectory/SomeFile.pdf";
            string fileName = GetFileNameFromPath(path);
        }
        public static string GetFileNameFromPath(string path)
        {
            string fileName = string.Empty;
            path = path.ReverseString();
            fileName = path.Substring(0, path.IndexOf(@"\"));
            fileName = fileName.ReverseString();
            return fileName;
        }
    }
    public static class StringExtension
    {
        public static string ReverseString(this string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
