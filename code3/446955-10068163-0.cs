    using System.IO;
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = @"c:\temp\file.txt";
            if (File.Exists(path))
            {
                Action();
            }
        }
    }
