    namespace csharp_station.howto
    {
    class TextFileWriter
    {
        static void Main(string[] args)
        {
            // create a writer and open the file
            TextWriter tw = new StreamWriter("date.txt");
            // write a line of text to the file
            tw.WriteLine(DateTime.Now);
            // close the stream
            tw.Close();
        }
    }
    }
    class TextFileReader
    {
        static void Main(string[] args)
        {
            // create reader & open file
            Textreader tr = new StreamReader("date.txt");
            // read a line of text
            Console.WriteLine(tr.ReadLine());
            // close the stream
            tr.Close();
        }
    }
