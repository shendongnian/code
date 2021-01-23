            //Declare variables so you can use them globally
            int number1, number2, sum, userSolution;
            Random numbers;
    
            private void btnProblem_Click(object sender, EventArgs e)
            {
                numbers = new Random();
    
                number1 = numbers.Next(400) + 101;
    
                number2 = numbers.Next(400) + 101;
    
                sum = number1 + number2;
    
                txtProblem.Text = number1 + "  +  " + number2;
            }
    
            private void btnSolution_Click(object sender, EventArgs e)
            {
                // You try to parse the text to a integer, if it works its stored in userSolution,
                // If it fails, it shows the messagebox
                if (!int.TryParse(txtSolution.Text, out userSolution))
                {
                    MessageBox.Show("Input is not a valid number.");
                }
                else
                {
                    // Check user solution and compare it to the sum
                    if (userSolution == sum)
                    {
                        MessageBox.Show("Correct!", "Problem Solved!");
                    }
                    else
                    {
                        MessageBox.Show("Not Correct.", "Please try again.");
                    }
                }
            }
