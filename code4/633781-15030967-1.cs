    using System.IO;
    using System.Text.RegularExpressions;
    class SampleSolution
    {
        public static void Main()
        {
            var path = @"C:\YourDirectory";
            foreach (string fileName in Directory.EnumerateFiles(path))
            {
                string changedName = Regex.Replace(fileName, @"\.\d+", string.Empty);
                if (fileName != changedName)
                {
                    File.Move(fileName, changedName);    
                }
            }
        }
    }
