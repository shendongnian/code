        int count = 0;
        private void Guess_Click(object sender, EventArgs e)
        {
            if (count < 100)
            {
                count++;
                // checks user input ...
            }
            else
            {
                count = 0;
                // reset the array by getting fresh numbers
                getNumbers();
            }
        }
