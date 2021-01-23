    var color = System.Drawing.Color.Red; //assume incorrect answer
    var label = "Incorrect";
    
    if (Answer2.Checked && Answer3.Checked && !Answer1.Checked && !Answer4.Checked)
    {
      //only the 2 correct answers have been checked
      color = System.Drawing.Color.Green;
      label = "Correct";
    }
    
    // set the controls
    lblQuestionResult4.ForeColor = color;
    lblQuestionResult4.Text = label;
