    private void button2_Click(object sender, EventArgs e)
    {
            if (R1P1.Checked) 
            {
                TxtP.Text = Plats1;  
                //anything declared here (i.e. a new variable)
            }//is gone by here
            else 
            {
                TxtP.Text = null;
                MessageBox.Show("Hey");
            }
     }
         
       
