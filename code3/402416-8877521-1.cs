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
}
