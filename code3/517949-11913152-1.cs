    [Export]
    public class ProblemViewModelFactory
    {
      private readonly IEnumerable<ExportFactory<Question, INameMetadata>> _questionFactories;
      
      [ImportingConstructor]
      public ProblemViewModelFactory(
        [ImportMany] IEnumerable<ExportFactory<Question, INameMetadata>> questionFactories)
      {
        if (questionFactories == null)
          throw new ArgumentNullException("questionFactories");
          
        _questionFactories = questionFactories;
      }
      
      public QuestionViewModel GetQuestionViewModel(string name)
      {
        return _questionFactories
          // Get matching question factories
          .Where(q => q.Metadata.Name == name)
          // Select the exported value
          .Select(q => q.CreateExport().Value)
          // First or default - what if the question doesn't exist?
          .FirstOrDefault();
      }
    }
