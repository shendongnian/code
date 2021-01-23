    private void button2_Click(object sender, EventArgs e)
    {
            if (R1P1.Checked) 
            {
                string Plats1 = "R1P1"; 
                TxtP.Text = Plats1;  
            }
            else 
            {
                TxtP.Text = null; 
                 MessageBox.Show("Hey");
            }
     }
         
       
