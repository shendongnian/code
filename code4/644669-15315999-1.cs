        private void Answer_Click(object sender, EventArgs e)
        {
             int userAnswer;
             if(!Int32.TryParse(txtAnswer.Text, out userAnswer))
                  MessageBox.Show("Please enter a number!");
             else
             {
                  if(userAnswer == Convert.ToInt32(theproblemLabel.Tag))
                      MessageBox.Show("Correct answer!");
                  else
                      MessageBox.Show("Wrong answer, try againg!");
             }
         }
