    public class QuestionnaireModel : Questionnaire
    {
        public new IList<QuestionGroupModel> QuestionGroups { get; set; }
    }
    public class QuestionGroupModel : QuestionGroup
    {
        public new IList<QuestionModel> Questions { get; set; }
    }
    public class QuestionModel : Question
    {
        public string SubmittedValue { get; set; }
    }
