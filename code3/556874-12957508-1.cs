    class Question
    {
    	public Question()
    	{
    		Answers = new string[4];
    	}
    	public string QuestionText{ get; set; }
    	public string[] Answers { get;set; }
    	public int CorrectAnswer {get;set; }
    }
