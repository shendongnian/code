    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    [MetadataAttribute]
    public class ExportQuestionAttribute : ExportAttribute, INameMetadata
    {
      public ExportQuestionAttribute(string name)
        : base(typeof(QuestionViewModel))
      {
        this.Name = name;
      }
      
      public string Name { get; private set; }
    }
