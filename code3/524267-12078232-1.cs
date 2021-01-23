    //input data into texbox8
    //TextBox tbox;
    double var1;
    private void tbox8_TextChanged(object sender, EventArgs e)
    {
        //tbox = sender as TextBox;
        var1 = Convert.ToDouble(tbox8.Text);
    }
    //display the result in textbox14
    //TextBox tbox2;
    //private void tbox14_TextChanged(object sender, EventArgs e)
    //{
        //tbox2 = sender as TextBox;
    //}
    //perform calculation and on button click display data on referenced textbox
    private void button3_Click(object sender, EventArgs e)
    {
        double result2 = var1 * 2;
        //if( tbox2 != null)
        //{
        tbox14.Text = result2.ToString(); 
        //}      
    }
