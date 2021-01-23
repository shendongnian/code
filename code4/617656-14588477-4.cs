    var questions = new List<Question>()
    {
        new Question { Text = "What is the capital of France?", Answer = "Paris" },
        new Question { Text = "What is the capital of Spain?", Answer = "Madrid" },
        new Question { Text = "What is the capital of Russia?", Answer = "Moscow" },
        new Question { Text = "What is the capital of Ukraine?", Answer = "Kiev" },
        new Question { Text = "What is the capital of Egypt?", Answer = "Cairo" }
    };
              
    Random random = new Random();
    
    // randomizing is very simple in this case
    foreach (var question in questions.OrderBy(q => random.Next()))
    {
        Console.WriteLine(question.Text);
    
        do
        {
            var answer = Console.ReadLine();
            if (question.IsCorrect(answer))
            {
                Console.WriteLine("It's True");
                break;
            }
    
            Console.WriteLine("It's False. Please try again.");
        }
        while (true);
    }
