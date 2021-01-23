    XDocument xdoc = XDocument.Load(@"C:\Users\Administrator\Desktop\questioon\questioon\QuestionAnswer.xml");
    string[] questions = xdoc.Root.Elements("Question").Select(x => (string)x).ToArray();
    string[] answers = xdoc.Root.Elements("Answer").Select(x => (string)x).ToArray();
    string[] userAnswers = new string[] { TextBox1.Text, TextBox2.Text, TextBox3.Text };
    for (int i=0 ; i < questions.Length ; i++)
    {
        // handle responses
        string[] words = answers[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(w => w.ToLower().Trim()).ToArray();
        string[] userWords = userAnswers[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(w => w.ToLower().Trim()).ToArray();
        string[] correctWords = words.Intersect(userWords);
        // do percentage calc using correctWords.Length / words.Length
    }
