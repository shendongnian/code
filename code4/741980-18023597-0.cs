    public class QuestionEditor
    {
        DbHandling db = new DbHandling();
        int questionId;
    	public QuestionEditor(int questionId)
    	{
            this.questionId = questionId;
    	}
    
        public void SetAnswer(string answerOption)
        {
            db.UpdateQuestion(qid, answerOption);
        }
    }
