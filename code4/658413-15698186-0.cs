    private Question _currentQuestion;
    private void AskQuestion(Question q)
    {
        _currentQuestion = q.GetQuestion();
        questionbox.Text =_currentQuestion;
    }
    private void Answer_Click(object sender, EventArgs e)
    {
       if (_currentQuestion != null)
       {
          if (_currentQuestion == answerbox.Text)
          {
              MessageBox.Show("well done");
          }
          else
          {
              MessageBox.Show("nope");
          }
       }
    }
