    public MainPage()
    {
        InitializeComponent();
        InputTextBox.Tap += InputTextBoxTap;
        InputTextBox.DoubleTap += InputTextBoxDoubleTap;
    }
    private void InputTextBoxDoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        InputTextBox.Text = "Double tapped!";
    }
    private void InputTextBoxTap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        InputTextBox.Text = "Tapped!";
    }
