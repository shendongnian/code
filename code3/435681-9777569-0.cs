    private void sumBtn_Click(object sender, EventArgs e)
    {
        //these should default to 0, but we should to it explicitly, just in case.
        int loopAnswer = 0;
        int number1;
        if(int.TryParse(number1Txtbox.Text, out number1)
        {
            for (counter = 1; counter <= 10; counter++)
            {
                loopAnswer += number1;
            }
            equalsBox.Text = loopAnswer.ToString();
        }
        else
            equalsBox.Text = "Not A Number";
    }
