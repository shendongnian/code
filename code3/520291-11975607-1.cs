            if (checkBox1.Checked == cb1
                && checkBox2.Checked == cb2
                && checkBox3.Checked == cb3
                && checkBox4.Checked == cb4
                && checkBox5.Checked == cb5
                && checkBox6.Checked == cb6)
            {
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
            else
            {
                MessageBox.Show("Unlucky, Guess Again!");
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox6.Visible = false;
            }
