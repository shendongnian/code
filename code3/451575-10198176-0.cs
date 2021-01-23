    public class Question_WithAnyOfficial: AbstractIndexCreationTask<Question>
    {
		public class Question_WithAnyOfficial()
		{
			Map = questions => from question in questions
                               // New Anonymous Type
							   select new
							   {
									Id = question.Id,
									CreatedOn = question.CreatedOn,
									Supporters = question.Supporters,
									Answers = question.Answers,
									AnyOfficial = question.Answers.Where(a => a.IsOfficial).Any()
							   };
		}
    }
	
