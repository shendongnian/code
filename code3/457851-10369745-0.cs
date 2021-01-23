    public class QuestionMap : ClassMap<Question>
    {
        public QuestionMap()
        {
            Id(x => x.QuestionId).GeneratedBy.Sequence("question_seq");
 
            Map(x => x.TheQuestion).Not.Nullable();
    
            HasMany(x => x.Answers).Inverse().Not.LazyLoad().Cascade.AllDeleteOrphan();
        }
    }
    public class AnswerMap : ClassMap<Answer>
    {
        public AnswerMap()
        {
            References(x => x.Question);
 
            Id(x => x.AnswerId).GeneratedBy.Sequence("answer_seq");
 
            Map(x => x.TheAnswer).Not.Nullable();
        }
    }
 
