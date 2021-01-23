    protected void insertAnswerTextBox_OnClick(object sender, EventArgs e)
    {
        PlaceHolder PlaceHolder1 = new PlaceHolder();
        // Get the number of textbox to create.
        int number = System.Convert.ToInt32(NumOfTextBoxes.Text);
        for (int i = 1; i <= number; i++)
        {
            TextBox AnswerTextBox = new TextBox();
            // Set the label's Text and ID properties.
            AnswerTextBox.Text = "AnswerTxtBox" + i.ToString();
            AnswerTextBox.ID = "AnswerTxtBox" + i.ToString();
            PlaceHolder1.Controls.Add(AnswerTextBox);
            // Add a spacer in the form of an HTML <br /> element.
            PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
        }
        form1.Controls.Add(PlaceHolder1); 
    }
