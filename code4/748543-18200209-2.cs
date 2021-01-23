       private void button1_Click(object sender, EventArgs e)
        {
            if(!checkBox1.Checked)
            {
                MessageBox.Show("You need the check box checked first!");
            }
            else
            {
                //changes the background color
                label1.BackColor = label1.BackColor == Color.Blue? Color.Red:Color.Blue;
                MessageBox.Show("The color is " + label1.BackColor.ToString());
            }
        }
