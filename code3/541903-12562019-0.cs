    public static void Display(List<Book> b, List<BookCategory> bc)
    {
        b.Sort();
        foreach (Book bk in b)
        {
            Console.WriteLine(bk.title  + (bk.price+10).ToString());
        }           
    }
