    //This routine sets up the problem for the user.
    private void btnGenerateProblem_Click(object sender, EventArgs e) { 
      //Get 2 random factors
      int x = Randomnumber.Next(12);
      int z = Randomnumber.Next(12);
      
      //Display the two factors for the user
      textBox2.Text = x.ToString(); 
      textBox3.Text = z.ToString(); 
    }
    //This routine checks the user's answer, and updates the "correct count"
    private void btnCheckAnswer_Click(object sender, EventArgs e) { 
      //Get the random numbers out of the text boxes to check the answer
      int x = int.Parse(textBox2.Text);
      int z = int.Parse(textBox3.Text);
      //Compute the true product
      int s = x * z; 
      //Does the true product match the user entered product?
      if (s == int.Parse(textBox4.Text))  {
        correct++; 
        numbercorrect.Text = correct.ToString(); 
      }
    }
