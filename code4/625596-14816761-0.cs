    public class StudentQuestion : List<Question>
    {
    	public int StudentId { get; set; }
    	
    	public StudentQuestion(int studentId, IEnumerable<Question> questions)
    	:base(questions)
    	{
    		StudentId = studentId;
    	}
    	
    	public bool AddAnswer(int id, string response)
    	{
    		Question question = null;
    		if((question = this.SingleOrDefault(q => q.Id == id)) == null)
    			return false;
    		
    		question.Answer = response;
    		return true;
    	}
    	
    	public bool RemoveAnswer(int id)
    	{
    		Question question = null;
    		if((question = this.SingleOrDefault(q => q.Id == id)) == null)
    			return false;
    		
    		question.Answer = string.Empty;
    		return true;
    	}
    	
    	public double ScoreTest(IEnumerable<Answer> answers)
    	{
    		List<bool> score = this.Join(answers, a1 => a1.Answer.Response, a2 => a2.Response, (a1, a2) => a1.HasCorrectAnswer(a2)).ToList();
    		return ((double)score.Where(s => s).Count()) / score.Count;
    	}
    }
    
    public class Question
    {
    	public int Id { get; set; }
    	public string Text { get; set; }
    	public Answer Answer { get; set; }
    	
    	public bool HasCorrectAnswer(Answer correctAnswer)
    	{
    		return correctAnswer == Answer;
    	}
    }
    
    public class Answer : IEquatable<Answer>
    {
    	public string Response { get; set; }
    	
    	public bool Equals(Answer answer)
    	{
    		if(answer == null) return false;
    		
    		return string.Compare(this.Response, answer.Response, true) == 0;
    	}
    	
    	public override bool Equals(object obj)
    	{
    		if(obj == null)
    			return false;
    		
    		var answerObj = obj as Answer;
    		return answerObj == null ? false : Equals(answerObj);
    	}
    	
    	public override int GetHashCode()
    	{
    		return Response.GetHashCode();
    	}
    	
    	public static bool operator == (Answer answer1, Answer answer2)
    	{
    		if ((object)answer1 == null || ((object)answer2) == null)
    			return object.Equals(answer1, answer2);
    			
    		return answer1.Equals(answer2);
    	}
    	
    	public static bool operator != (Answer answer1, Answer answer2)
    	{
    		if ((object)answer1 == null || ((object)answer2) == null)
    			return ! object.Equals(answer1, answer2);
    			
    		return ! (answer1.Equals(answer2));
    	}
    }
