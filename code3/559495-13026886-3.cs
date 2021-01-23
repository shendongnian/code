    public static List<Reference> GetReferencesForQuestionType()
    {
        return Enum.GetValues(typeof(QuestionType))
            .Cast<QuestionType>()
            .Select(x => new Reference
                             {
                                 PartitionKey = "00", 
                                 RowKey = (int)x, 
                                 Value = x.ToString()
                             })
            .ToList();
    }
