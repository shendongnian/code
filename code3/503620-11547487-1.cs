     protected void button1_Click(object sender, EventArgs e)
     {
       int safelyConvertedValue = -1;
       if(!System.Int32.TryParse(textBox1.Text, out safelyConvertedValue))
       {
         // The input is not a valid Integer value at all.
         MessageBox.Show("You need to enter a number between 1 an 9");
         // Abort processing.
         return;
       }
       // If you made it this far, the TryParse function should have set the value of the 
       // the variable named safelyConvertedValue to the value entered in the TextBox.
       // However, it may still be out of the allowable range of 0-9)
       if(safelyConvertedValue <0 || safelyConvertedValue > 0)
       {
         // The input is not within the specified range.
         MessageBox.Show("You need to enter a number between 1 an 9");
         // Abort processing.
         return;
       }
       MyProcessor p = new MyProcessor();
       textBox1.Text = p.AddTen(safelyConvertedValue).ToString();
     }
