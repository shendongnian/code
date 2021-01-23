    public class Questionnaire
    {
        public Questionnaire(int questionnaireId, string outputFile)
        {
             QuestionnaireId = questionnaireId;
             OutputFile = outputFile
        } 
        public int QuestionnaireId {get; private set;} 
        public string OutputFile { get; private set; }
        ...
    }
