     List<Question> list = new List<Question>;
     ......
     while (dataReader.Read())
     {
          Question qst = new Question();
          qst.ID = dataReader["id"] + "";
          qst.Difficulty = dataReader["difficulty"] + "";
          qst.Question = dataReader["qustions"] + "";
          qst.RightAnswer = dataReader["c_answer"] + "";
          qst.AnswerA = dataReader["choiceA"] + "";
          qst.AnswerB = dataReader["choiceB"] + "";
          qst.AnswerC = dataReader["choiceC"] + "";
          qst.AnswerD = dataReader["choiceD"] + "";
          list.Add(qst);
     }
     return list;
