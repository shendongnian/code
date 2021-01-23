    var question = new Question();
    question.QuestionText = "What color is snow?";
    question.Answers[0] = "Red";
    question.Answers[1] = "Yellow";
    question.Answers[2] = "White";
    question.Answers[3] = "Green";
    question.CorrectAnswer = 2;
    // ... more questions
    
    var listOfQuestions = new List<Question>();
    listOfQuestions.Add(question);
