    string text = "word1 word2 you it";
    List<Word> words = new System.Collections.Generic.List<Word>();
    words.Add(new Word() { SearchWord = "word1", ReplaceWord = "replaced" });
    words.Add(new Word() { SearchWord = "word2", ReplaceWord = "replaced" });
    words.ForEach(w => text = text.Replace(w.SearchWord, w.ReplaceWord));
