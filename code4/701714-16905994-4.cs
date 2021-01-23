    using System;
    public class Test
    {
        public static void Main()
        {
            string path = "Some Directory/Some SubDirectory/SomeFile.pdf";
            string fileName = GetFileNameFromPath(path);
            Console.WriteLine(fileName);
        }
        public static string GetFileNameFromPath(string path)
        {
            string fileName = string.Empty;
            path = path.ReverseString();
            fileName = path.Substring(0, path.IndexOf(@"/"));
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
