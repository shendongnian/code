    Label changeMe = new Label();
    public Form1()
    {
        InitializeComponent();
        Label changeMe = new Label();
        changeMe.AutoSize = true;
        changeMe.Left = 50; changeMe.Top = 50;
        changeMe.Text = "Change this text from other function";
        changeMe.IsAccessible = true;
        //changeMe.Name = "changeMe";
        this.Controls.Add(changeMe);
    }
