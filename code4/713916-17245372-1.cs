        if (count == 2)
            {
                MessageBox.Show("Congrats You Score is : " + Marks, "Result", MessageBoxButtons.OK);
                this.Close();
            }
        else
            {
               string choice = src.ReadLine();
               string ques = srq.ReadLine();
               opt = choice.Split('\t'); 
               label1.Font = new Font("Times New Roman", 15);
               label1.Text = ques;
               ch1.Font = new Font("Times New Roman", 15);
               ch1.Text = opt[0];
               ch2.Font = new Font("Times New Roman", 15);
               ch2.Text = opt[1];
               ch3.Font = new Font("Times New Roman", 15);
               ch3.Text = opt[2];
               ch4.Font = new Font("Times New Roman", 15);
               ch4.Text = opt[3];  
            }
