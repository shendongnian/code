    private void PopulateForm()
    {
        int count = 0;
        foreach (var question in _questions)
        {
            var button = new Button();
            button.Size = new Size(60, 23);
            button.Location = new Point(100, 40 + (count * 30));
            button.Text = question.QuestionText;
            Controls.Add(button);
            count++;
        }
    }
