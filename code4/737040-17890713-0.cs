    public class Application
    {
      public static void Main()
      {
        var repo = new Repository();
        foreach (var topBook in repo.findby(Service.getTopNewBooks))
        {
          // This is a matching top book
        }
      }
    }
    public class Repository
    {
      public List<Book> findby(Func<IEnumerable<Book>,IEnumerable<Book>> query)
      {
        var dbcontext = DataContextFactory.GetDataContext();
        List<Book> matchedBooks = query(dbcontext.Books).ToList(); 
        return matchedBooks;
      }
    }
    public class Service
    {
      public static IEnumerable<Book> getTopNewBooks(IEnumerable<Book> input)
      {
        return input.Where(B=>B.New==true && B.Id>99).OrderBy(B=>B.Date).ThenBy(B=>B.Id).Skip(2).Take(10);
      }
    }
