    UserControl1.InsertCharacter(string character)
    {
        textBox1.Text = textBox1.Text.Insert(textBox1.CaretIndex, character); 
        this.ValidateInput();
    }
    UserControl1.ValidateInput()
    {
        // Perform validation
    }
    UserControl1.OnKeyDown()
    {
        // Perform validation
        this.ValidateInput();
    }
    UserControl2.AppendCharacter(string clickedCharacter)
    {
        this.userControl1.InsertCharacter(clickedCharacter); 
    }
