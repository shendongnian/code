    class Sentence
    {
       string[] words = "The quick brown fox".Split();
       public string this [int wordNum] // indexer
       {
          get { return words [wordNum]; }
          set { words [wordNum] = value; }
       }
    }
