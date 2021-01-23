    internal class QuestionData
    {
      [BsonId] public Guid Id { get; set; }
      [BsonElement("type")] public string Type { get; set; }
      [BsonElement("qnotes")] public QuestionNote[] QuestionNotes { get; set; }
    }
  
    [BsonNoId] internal class QuestionNote
    {
      [BsonElement("q")] public string Question { get; set; }
      [BsonElement("n")] public string Note { get; set; }
    }
    
