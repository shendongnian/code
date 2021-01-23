    public Form1()
    {
        InitializeComponent();
        button1.Click += new EventHandler(button1_Click); //Link the Click event of button1 to button1_Click
    }
    
    const int MaximumClicks = 5; //Initialize a new constant int of value 5 named MaximumClicks
    int CurrentClicks = 0; //Initialize a new variable of name CurrentClicks as an int of value 0
