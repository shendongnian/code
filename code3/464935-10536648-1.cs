    [Export(typeof(IWordsRepository))]
    public class WordsRepository : IWordsRepository
    {
       public List<Word> FetchAll()
       {
           //this class will hit the database
       }
    }
    [Export(typeof(IWordsRepository))]
    public class WordsRepositoryTest : IWordsRepository
    {
       public List<Word> FetchAll()
       {
            //this class will not go to the database, maybe an xml file or something.    
       } 
    }
