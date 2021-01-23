        public class Survey
        {
            public int SurveyId { get; private set; }
            public string Title { get; private set; }
            public int BrandId { get; private set; }
            public DateTime Created { get; private set; }
            public IList<SurveyQuestionBlock> QuestionBlocks { get; private set; }
            public string Name { get; private set; }
    
            public void AddQuestionBlock(string questionBlockInfo)
            { 
              this.QuestionBlocks.Add(new SurveyQuestionBlock(...));
            }
    
            public Survey()
            {
                Created = DateTime.Now;
                QuestionBlocks = new List<SurveyQuestionBlock>();
            }
        }
