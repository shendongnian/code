    public DataSet getPageDB(string myQuery, string ConnStr)
    {
        OleDbDataAdapter oda = new OleDbDataAdapter   (myQuery, ConnStr);
        DataSet ds = new DataSet();
        oda.Fill(ds);
        foreach(DataRow pRow in ds.Tables[0].Rows){ //here if there are no tables in the dataset. So you must check if(ds.Tables.Count > 0) before executing the for loop.
             //What is _currentQuest? Have you initialised it with a new keyword? Is it null when you try to use it?
            _currentQuest.question=pRow["question"].ToString();
            _currentQuest.questionNumber =Convert.ToInt16( pRow["questionnumber"]);
            _currentQuest.rightAnswer=pRow["answer"].ToString();
            _currentQuest.goodFeedBack=pRow["goodfeedback"].ToString();
            _currentQuest.badFeedBack1=pRow["badfeedback1"].ToString();
            _currentQuest.badFeedBack2=pRow["badfeedback2"].ToString();
            //What is AllQuestions? make sure that this is not null.
            AllQuestions.Add(_currentQuest);
        }
        return ds;
    }
