        private void Guess_button_Click(object sender, EventArgs e)
        {
            int boxesChecked = 0;   // Default value
            List<CheckBox> AllTheCheckBoxes = new List<CheckBox> { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6 };
            boxesChecked = AllTheCheckBoxes.Where<CheckBox>(x => x.Checked).Count();
            if (boxesChecked != 3)
            {
                MessageBox.Show(string.Format("You have checked {0} checkboxes. Please choose 3.", boxesChecked));
                return;
            }
            if (AllTheCheckBoxes.Any<CheckBox>(x => x.Checked != Convert.ToBoolean(x.Tag)))
            {
                MessageBox.Show("Unlucky, Guess Again!");
                AllTheCheckBoxes.ForEach(x => x.Visible = false);
                return;
            }
            MessageBox.Show("Congratulations, You Win!", "Game Won"); // Display MessageBox
            if (MessageBox.Show("Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                p1input restart = new p1input();
                this.Close();   // Close current window
                restart.Show(); // Open restart (instance of p1input)
            }
            else
            {
                Environment.Exit(0);    // Terminate Application
            }
        }
