    namespace HymmParser
    {
    class Program
    {
        const string TITLE_REGEX = @"\s*\d+\s{2,}[a-zA-Z]+";
        static void Main(string[] args)
        {
            var hymns = new List<Hymn>();
            //read the file
            string[] lines = System.IO.File.ReadAllLines(@"C:\HymnWords.txt");
            for (int i = 0; i < lines.Count(); i++)
            {
                //regex to check for a white space, a number, 2 or more white spaces then words after.
                if (Regex.IsMatch(lines[i], TITLE_REGEX))
                {
                    var hymn = new Hymn
                    {
                        //TODO: Add your title parse logic here.
                        Title = lines[i]
                    };
                    //find verses under this hymn
                    for (i++; i < lines.Count(); i++)
                    {
                        //ensure this line is not a title, else break out of it.
                        if (Regex.IsMatch(lines[i], TITLE_REGEX))
                        {
                            break;
                        }
                        //if number only found, this is the start of a verse
                        if (Regex.IsMatch(lines[i], @"^\s*\d+$"))
                        {
                            var verse = new Verse(int.Parse(lines[i]));
                            //gather up verse lines
                            for (i++; i < lines.Count(); i++)
                            {
                                //if number only, break.
                                if (Regex.IsMatch(lines[i], @"\s*\d+"))
                                {
                                    //backup and break, outer loop will increment and miss this new verse
                                    i--;
                                    break;
                                }
                                else if (string.IsNullOrWhiteSpace(lines[i]))
                                {
                                    //if whitespace, then we may have finished the verse, break out
                                    break;
                                }
                                else
                                {
                                    verse.VerseLines.Add(lines[i]);
                                }
                            }
                            hymn.Verses.Add(verse);
                        }
                    }
                    hymns.Add(hymn);
                }
            }
            foreach (var hymn in hymns)
            {
                Console.WriteLine(hymn.Title);
                foreach (var verse in hymn.Verses)
                {
                    Console.WriteLine(verse.VerseNumber);
                    foreach (var line in verse.VerseLines)
                    {
                        Console.WriteLine(line);
                    }
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("Hymns Found: {0}", hymns.Count);
           
            Console.ReadLine();
        }
    }
    public class Hymn
    {
        public Hymn()
        {
            Verses = new List<Verse>();
        }
        public string Title { set; get; }
        public List<Verse> Verses { set; get; }
    }
    public class Verse
    {
        public Verse(int verseNumber)
        {
            VerseNumber = verseNumber;
            VerseLines = new List<string>();
        }
        public int VerseNumber { get; private set; }
        public List<string> VerseLines { set; get; }
    }
}
