    public class AnsweredQ
        {
            public string Question { get; set; }
            public string Answer { get; set; }
    
           public AnsweredQ() {  }
    
    
            public AnsweredQ(string _Question, string _Answer)
            {
                Question = _Question;
                Answer = _Answer;
            }
        }
        public class UnAnsweredQ
        {
    
    
            public string Question { get; set; }
            public string[] Options { get; set; }
    
            public UnAnsweredQ() {}
    
            public UnAnsweredQ(string _Question, string[] _Options)
            {
                Question = _Question;
                Options = _Options;
            }
        }
    
    
        public class Trial
        {
            public string User { get; set; }
            public DateTime TrialDate { get; set; }
            public bool Expired { get; set; }
    
            public Trial ()
            {
            }
    
            public Trial (string _User, DateTime _TrialDate, bool _Expired)
            {
                User = _User;
                TrialDate = _TrialDate;
                Expired = _Expired;
            }
        }
    }
