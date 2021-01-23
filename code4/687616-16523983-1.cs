    [Serializable]
    public partial class Answer
    {
        public int AnswerKey { get; set; }                   
        public int ParentQuestionID { get; set; }
        public string AnswerText { get; set; }                   
    	
    	public Question ParentQuestion  { get; set; }    
    	
    }
    
    internal static class AnswerDefaultLayout
    {
        public static readonly int AnswerKey = 0;
        public static readonly int ParentQuestionID = 1;
        public static readonly int AnswerText = 2;
    
    }
    
    public class AnswerSerializer
    {
        public ICollection<Answer> SerializeAnswers(IDataReader dataReader)
        {
            Answer item = new Answer();
            ICollection<Answer> returnCollection = new List<Answer>();
    
                int fc = dataReader.FieldCount;//just an FYI value
    
                int counter = 0;//just an fyi of the number of rows
    
                while (dataReader.Read())
                {
    
                    if (!(dataReader.IsDBNull(AnswerDefaultLayout.AnswerKey)))
                    {
                        item = new Answer() { AnswerKey = dataReader.GetInt32(AnswerDefaultLayout.AnswerKey) };
    
                        if (!(dataReader.IsDBNull(AnswerDefaultLayout.ParentQuestionID)))
                        {
                            item.ParentQuestionID = dataReader.GetInt32(AnswerDefaultLayout.ParentQuestionID);
                        }
    
                        if (!(dataReader.IsDBNull(AnswerDefaultLayout.AnswerText)))
                        {
                            item.AnswerText = dataReader.GetString(AnswerDefaultLayout.AnswerText);
                        }
    
      
                        returnCollection.Add(item);
                    }
    
                    counter++;
                }
    
                return returnCollection;
    
        }
    	}
    
    
    [Serializable]
    public class Question
    {
        public int QuestionID { get; set; }
        public string Question { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
    
    internal static class QuestionDefaultLayout
    {
        public static readonly int QuestionID = 0;
        public static readonly int QuestionText = 1;
    }
    
    
    public class QuestionSerializer
    {
        public ICollection<Question> SerializeQuestions(IDataReader dataReader)
        {
            Question item = new Question();
            ICollection<Question> returnCollection = new List<Answer>();
    
    
                int fc = dataReader.FieldCount;//just an FYI value
    
                int counter = 0;//just an fyi of the number of rows
    
                while (dataReader.Read())
                {
    
                    if (!(dataReader.IsDBNull(QuestionDefaultLayout.QuestionID)))
                    {
                        item = new Question() { QuestionID = dataReader.GetInt32(QuestionDefaultLayout.QuestionID) };
    
                        if (!(dataReader.IsDBNull(QuestionDefaultLayout.LAST_NAME)))
                        {
                            item.LastName = dataReader.GetString(QuestionDefaultLayout.LAST_NAME);
                        }
    
    
    
                        returnCollection.Add(item);
                    }
    
                    counter++;
                }
    
                return returnCollection;
    
    
        }
    }
    
    
    
    
    
    
    public class QuestionManager
    {
    
    	public ICollection<Question> GetAllQuestionsWithChildAnswers()
    	{
    
        String myConnString  = "User ID=<username>;password=<strong password>;Initial Catalog=pubs;Data Source=myServer";
        SqlConnection myConnection = new SqlConnection(myConnString);
        SqlCommand myCommand = new SqlCommand();
        SqlDataReader myReader ;
    
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.Connection = myConnection;
        myCommand.CommandText = "dbo.uspQuestionAndAnswersGetAll";
        int RecordCount=0; 
    
        try
        {
            myConnection.Open();
    		myReader = myCommand.ExecuteReader();
    
    		ICollection<Question> questions = new QuestionSerializer().SerializeQuestions(myReader);
    
    		myReader.NextResult();
    
    		ICollection<Answer> answers = new AnswerSerializer().SerializeAnswers(myReader);
    		
    		questions = this.MergeQuestionObjectGraphs(questions, answers);
    
        catch(Exception ex) 
        {
           MessageBox.Show(ex.ToString());
        }
        finally
        {
    	if (null != myReader)
    	{
    		myReader.Close();
    	}
    	if (null != myConnection)
    	{
    		myConnection.Close();
    	}
        }
    	}
    	
            private ICollection<Question> MergeQuestionObjectGraphs(ICollection<Question> qtions, ICollection<Answer> aners)
            {
                if (null != qtions && null != aners)
                {
                    foreach (Question qtn in qtions)
                    {
                        IEnumerable<Answer> foundLinks = aners.Where(lnk => lnk.ParentQuestionId == qtn.QuestionId);
                        if (null != foundLinks)
                        {
                            foreach (Answer link in foundLinks)
                            {
                                link.ParentQuestion = qtn;
                            }
    
                            qtn.Answers = foundLinks.ToList();
                        }
                    }
                }
    
                return qtions;
            }
    
    }
    
    
    
    
    
