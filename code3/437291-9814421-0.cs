    public class QuestionnaireWrapper: Questionnaire {
    
        private Questionnaire _q;
    
        public QuestionnaireWrapper(int id)
        {
            _q = (from q in db.Questionnaires
                where q.Id == id
                select q).SingleOrDefault();
        }
    
        public new string Name 
        {
            get { return _q.Name; }
            set { _q.Name = value; }
        }
        [Other overrides, all of them]
    }
