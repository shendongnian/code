    public List<Book> GetBookList()
    {
      List<Book> objBooks=new List<Book>();
    
      using (StreamReader file = new StreamReader(@"C:\dataist.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
    
                    char[] delimiters = new char[] { ',' };
                    string[] parts = line.Split(delimiters);
                     
                     Book objBook=new Book();
                     objBook.BookCode=parts[0];
                     objBook.BookTitle =parts[0];
                     objBook.BookPrice =Convert.ToDecimal(parts[0]);
                     objBook.Quantity =Convert.ToInt32(parts[0]);
                
                     objBooks.Add(objBook);
    
                }
    
                file.Close();
            }
    
    return objBooks;
    }
