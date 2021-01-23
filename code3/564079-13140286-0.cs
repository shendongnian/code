    private void button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=MANINOTEBOOK\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Casesheet");
      try
      {
        con.Open();
        SqlCommand cmd = new SqlCommand("select PatientID from FTR where PatientID='" + textBox1.Text + "'", con);
        textBox2.Text = cmd.ExecuteScalar().ToString();
        if (textBox2.Text == textBox1.Text)
        {
            Consultation cs = new Consultation(textBox1.Text);
            cs.Show();
        }
        else
        {
            MessageBox.Show("Data not found");
        }    
      } 
       catch(NullReferenceException ex)
       {
       Console.Write(ex.message);
       }     
    }
