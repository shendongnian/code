     private void btnSubmit_Click(object sender, EventArgs e)
        {
            string guessedWord = textBoxGuessedWord.Text;
            if (guessedWord == _secretWord)
            {
                _guessedCorrectly = true;
            }
            else
            {
                _guessedCorrectly = false;
            }
        }
