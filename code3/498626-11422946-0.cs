    string words = "This is a list of words, with: a bit of punctuation" +
                           "\rand a newline character.";
    
    string [] split = words.Split(new Char [] {'\r' });
    
    foreach (string s in split) {
        if (s.Trim() != "")       
            Console.WriteLine(s);
    }
