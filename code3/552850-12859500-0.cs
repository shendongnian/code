    class Program
    {
        static void Main(string[] args)
        {
            Stream stream = typeof(Program).Assembly.GetManifestResourceStream("TheNameOfMyProject.TheNameOfSubFolder.file.txt");
            StreamReader sr = new StreamReader(stream);
            var content = sr.ReadToEnd();
            Console.WriteLine(content);
            Console.ReadLine();
        }
    }
