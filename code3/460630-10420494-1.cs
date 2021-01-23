       int i = 1;
       while (da.Read())
       {
            //Details.Add("QuestionNumber1", da["UserAnswer"]);
            //Details.Add("QuestionNumber2", da["UserAnswer"]);
            //...
             Details.Add("QuestionNumber" + i, da["UserAnswer"]);
             i = i + 1;
        }
