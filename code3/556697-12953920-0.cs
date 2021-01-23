    class Sentence
    {
        string[] words = "The quick brown fox".Split();
        public string this [int wordNum] // indexer
        {
           get { return words [wordNum]; }
           set { words [wordNum] = value; }
        }
    }
    Sentence s = new Sentence();
    Console.WriteLine (s[3]); // fox
    s[3] = "kangaroo";
    Console.WriteLine (s[3]); // kangaroo
