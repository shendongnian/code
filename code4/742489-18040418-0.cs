    string text = "word1 word2 you it";
    List<string> words = new System.Collections.Generic.List<string>();
    words.Add("word1");
    words.Add("word2");
    words.ForEach(w => text = text.Replace(w, ""));
