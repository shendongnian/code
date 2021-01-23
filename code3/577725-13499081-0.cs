    List<RadioButton> buttons = new List<RadioButton>();
    buttons.Add(answer);
    buttons.Add(answer2);
    buttons.Add(answer3);
    buttons.Add(answer4);
    
    int goodAnswerPos = random.Next(buttons.Count);
    buttons[goodAnswerPos].Text = "Good Answer";
    buttons.RemoveAt(goodAnswerPos);
    
    foreach (RadioButton button in buttons)
    {
        button.Text = "Randomly Selected Wrong Answer";
    }
