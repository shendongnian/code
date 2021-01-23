    int number;
    if(string.IsNullOrEmpty(guessInput.Text))
    {
      MessageBox.Show("You did not enter an integer, please enter a integer", "Invalid Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }
    if(Int32.TryParse(guessInput.Text, out number))
    {
      guessInt = number; 
    }else
    {
      MessageBox.Show("You did not enter an integer, please enter a integer", "Invalid Values",      MessageBoxButtons.OK, MessageBoxIcon.Error);
       guessInput.Text = "";
       return;
    }
    // when come to here you have guessInt, process it 
       guess.Enabled = false;
        next_Guess.Enabled = true;
        if (guessInt == randomArray[x])
        {
            result.Text = ("You Win! The correct number was " + randomArray[x]);
            right += 1;
            correctAnswers.Text = right.ToString();
        }
        else
        {
            result.Text = ("Sorry you lose, the number is " + randomArray[x]);
            wrong += 1;
            incorrectAnswers.Text = wrong.ToString();
        }
        hintLabel.Enabled = false;
        x++;
