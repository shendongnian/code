    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace TestApp
    {
    public class Log
    {
        protected static string GetFileName()
        {
            return "log.txt";
        }
        public Log()
        {
        }
        public static void Write(string message)
        {
            System.IO.File.AppendAllText(GetFullFilePath(), message + Environment.NewLine);
        }
        public static string ReadAll()
        {
            return System.IO.File.ReadAllText(GetFullFilePath());
        }
        private static string GetFullFilePath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, GetFileName());
        }
    }
    }
