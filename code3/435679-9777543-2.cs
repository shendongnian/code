    private void sumBtn_Click(object sender, EventArgs e)
    {
        int counter;
        int loopAnswer = 0;
        int number1 = int.Parse(number1Txtbox.Text);
        for (counter = 1; counter <= 10; counter++)
        {
            loopAnswer += number1; //same as loopAnswer = loopAnswer + number1;
        }
        equalsBox.Text = loopAnswer.ToString();
    }
