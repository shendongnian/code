    using System.IO;
    private static void logWrite(string filename, string text)
    {
        string filepath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + filename;
    
        using (StreamWriter sw = File.AppendText(filepath))
        {
            sw.WriteLine(text);
            Console.WriteLine(text);
        }
    }
