    private void PopulateForm()
    {
        foreach (var question in _questions)
        {
            var button = new Button();
            button.Size = new Size(60, 23);
            button.Location = new Point(100, 200);
            button.Text = question.QuestionText;
            Controls.Add(button);
        }
    }
