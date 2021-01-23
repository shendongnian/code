        from info in list
    	where info != null
        select new
        {
            Question = info.QuestionText ?? "Test",
            CorrectAnswer = info.CorrectAnswer.OptionText ?? "Test",
            WrongAnswer1  = info.WrongAnswer1 !=null ? info.WrongAnswer1.OptionText : "Test",
            WrongAnswer2  = info.WrongAnswer2 !=null ? info.WrongAnswer2.OptionText : "Test", 
            WrongAnswer3  = info.WrongAnswer3 !=null ? info.WrongAnswer3.OptionText : "Test"
        };
