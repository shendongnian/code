    private void button1_Click(object sender, EventArgs e)
    {
         int firstInt = -1;
         int secondInt = -1;
    
        if(!System.Int32.TryParse(txtbox1.Text, out firstInt)
        {
           MessageBox.Shw("Invalid value in Textbox 1");
           return; // Stop procesing
        }
        if(!System.Int32.TryParse(txtbox2.Text, out secondInt)
        {
           MessageBox.Show("Invalid value in Textbox 2");
           return; // Stop procesing
    
        }
              //Here i want to add the values from two text boxes values as given below.
              mySum(firstInt, secondInt); //Here it shows me the error . Please help me.           
        }
