     private string[] quizList;
    
     public string[] getQuizList() 
     {    
         Databases.MoodleOCDataSetTableAdapters.QuizTableAdapter ta = new Databases.MoodleOCDataSetTableAdapters.QuizTableAdapter();
         Databases.MoodleOCDataSet.QuizDataTable table = new Databases.MoodleOCDataSet.QuizDataTable();
         ta.Fill(table);
    
         System.Data.DataRow[] row = table.Select("id > 0");
         quizList = new string[row.Length];
    
         for(int i = 0; i < row.Length; i++)    
             quizList[i] = row[i].ItemArray[2].ToString();
    
         return quizList;
     }
