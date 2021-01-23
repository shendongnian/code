    public class WordExamples 
    {
       public string Word { get; private set; }
       public List<Sentence> SentencesWithWord { get; private set; }
       public WordExamples(string word, List<Sentences> sentences) {
          Word = word;
          // TODO: Consider cloning instead
          SentencesWithWord = sentences;
       }
    }
