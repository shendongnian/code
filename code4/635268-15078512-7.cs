    private void PopulateForm()
    {
        foreach (var question in _questions)
        {
            label1.Text = question.QuestionText;
            button1.Text = question.Answers[0];
            button2.Text = question.Answers[1];
            button3.Text = question.Answers[2];
            button4.Text = question.Answers[3];
        }
    }
