    XDocument xdoc = XDocument.Load(@"C:\Users\Administrator\Desktop\questioon\questioon\QuestionAnswer.xml");
    string[] questions = xdoc.Root.Elements("Question").Select(x => (string)x).ToArray();
    string[] answers = xdoc.Root.Elements("Answer").Select(x => (string)x).ToArray();
    string[] userAnswers = new string[] { TextBox1.Text, TextBox2.Text, TextBox3.Text };
    for (int i=0 ; i < questions.Length ; i++)
    {
        // handle responses
    }
