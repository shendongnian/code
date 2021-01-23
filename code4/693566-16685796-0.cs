    private string someText;
    public MyForm()
    {
        InitializeComponent();
        TextBlock1.Text = someText; // At this point, someText == null
    }
    private void Button_Click(object sender, EventArgs e)
    {
        someText = inputText.Text;
    }
