    ExamAnswers = obj_Methods.GetExamAnswers(Convert.ToInt32(Request.QueryString["uid"]));
    if (ExamAnswers.Count > 0)
    {
          Q1Answer.Text = ExamAnswers["QuestionNumber1"].value;
          Q2Answer.Text = ExamAnswers["QuestionNumber2"].value;
          Q3Answer.Text = ExamAnswers["QuestionNumber3"].value;
          ...
    }
