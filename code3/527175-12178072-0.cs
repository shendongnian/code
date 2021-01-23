    public string QuestionText { get; set; }
    
    public override void ViewDidLoad()
    {
       base.ViewDidLoad();
    
       txtBox.Text = QuestionText;
    }
