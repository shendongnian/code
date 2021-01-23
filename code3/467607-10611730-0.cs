    int number;
    if(Int32.TryParse(guessInput.Text, out number))
    {
      guessInt = number; 
    }else
    {
      MessageBox.Show("You did not enter an integer, please enter a integer", "Invalid Values",      MessageBoxButtons.OK, MessageBoxIcon.Error);
       guessInput.Text = "";
    }
