    //Form 2
    public Form1 MyMainForm {get; set;}
    
    private void button1_Click(object sender, EventArgs e)
    {
        //Your code ...
    	
        if (reader.Read())
        {
            MessageBox.Show("Welcome " + reader["UserName"].ToString());
            
            MyMainForm.button1.Enabled = true;
            
    		//If you are already id Form2
            this.Close();
        }
        else
        {
            MessageBox.Show("Username and password " + 
                textBox1.Text + "does not exist");
        }
    }
