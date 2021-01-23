    if (checkBox1.Checked)
                 {
                     if(!listBox1.Items.Contains("Anchovies"))
                         listBox1.Items.Add("Anchovies");
                     double total = Convert.ToDouble(textBox2.Text);
                     total = total + .5;
                     textBox2.Text = Convert.ToString(total);
                }      
   
