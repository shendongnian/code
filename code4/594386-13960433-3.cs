    foreach (var section in query)
    {
        Console.WriteLine("Section{0}: {1}", section.SectionID, section.SectionText);
    
        foreach (var result in section.Results)
            Console.WriteLine("Question {0}. {1}: {2}", 
                result.DisplayOrder, result.QuestionText, result.AnswerValue);
        
        Console.WriteLine();
    }
