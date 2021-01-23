    public static Reference ToReference(this QuestionType questionType)
    {
        return new Reference
                         {
                             PartitionKey = "00", 
                             RowKey = (int)questionType, 
                             Value = questionType.ToString()
                         };
    }    
