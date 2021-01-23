    public class Info
    {
       public string Title { get; private set; }
       public string BookOrJournal { get; private set; }
       public IEnumerable<string> Authors { get; private set; }
       //more members of pages, year etc.
       public Info(string stringFromFile)
       {
         Title = /*read book name from stringFromFile */;
         BookOrJournalName = /*read journal name from stringFromFile */;
         Authors = /*read authors from stringFromFile */;
       }
    }
