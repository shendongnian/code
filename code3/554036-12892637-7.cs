    public string QuestionText
    {
        get
        {
            return (string)GetValue(QuestionTextProperty);
        }
        set
        {
            SetValue(QuestionTextProperty, value);
            questionText.Text = value; //set the textbox content
        }
    }
    public static DependencyProperty QuestionTextProperty = DependencyProperty.Register("QuestionText", typeof(string), typeof(Deck), new PropertyMetadata(""));
    ...
