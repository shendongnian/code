    //somewhere in your form object, probably InitializeComponent()
    ARadioButton1.CheckChanged += new EventHandler(ARadioButton_CheckedChanged);
    ARadioButton2.CheckChanged += new EventHandler(ARadioButton_CheckedChanged);
    ARadioButton3.CheckChanged += new EventHandler(ARadioButton_CheckedChanged);
    protected void ARadioButton_CheckedChanged(object sender, EventArgs e)
    {
        if (sender is RadioButton)
        {
            RadioButton radioButton = (RadioButton)sender;
            label1.Text = "Clicked " + radioButton.Name;
        }
    }
