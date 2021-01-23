    public static IEnumerable<Book> ReadBooks(string filename)
    {
        using (var f = File.Open(filename, FileMode.Open))
        {
            using (BinaryReader rdr = new BinaryReader(f))
            {
                Book b = new Book();
                //.....
                yield return b;
            }
        }
    }
