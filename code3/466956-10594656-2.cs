    public class Info
    {
       public string BookName { get; private set; }
       public string JournalName { get; private set; }
       public string AuthorName { get; private set; }
       public Info(string stringFromFile)
       {
         BookName = /*read book name from stringFromFile */;
         JournalName = /*read journal name from stringFromFile */;
         AuthorName = /*read author name from stringFromFile */;
       }
    }
