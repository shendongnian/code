    private void radioButton_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton rb = (RadioButton)sender;
        Question q = questionList[index];
        //if checkbox is checked
        //displaying text in separate two lines on messagebox
        if (rb.Checked && q.RightAnswer == rb.Text)
        {
            // Move your code to another method
            // MessageBox.Show("Well Done" + Environment.NewLine + "You Are Right");
            UserSelectedCorrectAnswer();
        }
        else if (rb.Checked)
        {
            // They checked the radio button, but were wrong!
            // MessageBox.Show("Sorry" + Environment.NewLine + "You Are Wrong");
            UserSelectedWrongAnswer();
        }
    }
