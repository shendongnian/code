    foreach (var y in x.AdditionalQuestionAnswers)
    {
    	AdditionalQuestionAnswerModel newObj = new AdditionalQuestionAnswerModel
    	{
    		 QuestionText = x.QuestionText;
    		 InstitutionId = x.InstitutionId;
    		 AdditionalQuestionId = x.Id;
    		 AnswerText = y.AnswerText;
    		 IsSelected = false;
    	};
    	
    	_model.AddQuestAnswModel.Add(newObj);
    }
