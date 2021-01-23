    string line;
    using (var sr = new StreamReader("answers.txt"))
    {
    	while ((line = sr.ReadLine()) != null)
    	{
    		for (int iCountLine = 0; iCountLine < 10; iCountLine++)
    		{
    			var answers = line.Split(',');
    			for (int iCountAnswer = 0; iCountAnswer < 4; iCountAnswer++)
    			{
    				sQuestionAnswers[iCountLine, iCountAnswer] = answers[iCountAnswer];
    			}
    		}
    	}
    }
