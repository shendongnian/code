      this.label7.Click += new System.EventHandler(this.label7_Click);
        void label7_Click(object sender, EventArgs e)
        {
             MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        {
            //
        }
        else { 
            Application.Exit(); 
        }
        }
No overload for 'label7_Click' matches delegate
    public void label7_Click(object sender, FormClosingEventArgs e)//this method de is incorrect
