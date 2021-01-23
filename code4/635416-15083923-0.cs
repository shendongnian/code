    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {           
            if (checkBox1.Checked)
             {
                 //If the item is already there, we don't do anything.
                 if (!listBox1.Items.Contains("Anchovies")) {
                     listBox1.Items.Add("Anchovies");
                     double total = Convert.ToDouble(textBox2.Text);
                     total = total + .5;
                     textBox2.Text = Convert.ToString(total);
                 }
            }            
    }
