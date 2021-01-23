    foreach (var subjectGroup in grouped)
    {
        Console.WriteLine("Subject {0}", subjectGroup.SubjectId);
        foreach (var parentGroup in subjectGroup.Groups)
        {
            Console.WriteLine("\tParent {0}", parentGroup.Key);
            foreach (var question in parentGroup)
            {
                Console.WriteLine("\t\tQuestion {0}", question.QuestionId);
            }
        }
    }
