     protected void b_Click(object sender, EventArgs e)
        {
            Button snder  = sender as Button;
                  
            //for the first time just assign this button
            if (currentBtn == null)
            {
                currentBtn = snder;
            }
            else //for the second time and beyond
            {
                //change the previous button to previous colour. I assumed red
                currentBtn.BackColor = System.Drawing.Color.Red;
                //assign the newly clicked button as current
                currentBtn = snder;
            }
            //change the newly clicked button colour to "Active" e.g green
            currentBtn.BackColor = System.Drawing.Color.Green;
        }
