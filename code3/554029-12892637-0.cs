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
    public string AnswerText
    {
        get
        {
            return (string)GetValue(AnswerTextProperty );
        }
        set
        {
            SetValue(AnswerTextProperty , value);
            questionText.Text = value; //set the textbox content
        }
    }
    public static DependencyProperty AnswerTextProperty = DependencyProperty.Register("AnswerText", typeof(string), typeof(Deck), new PropertyMetadata(""));
