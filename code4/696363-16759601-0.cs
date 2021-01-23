        protected void TextBox2_TextChanged(object sender,EventArgs e)
        {
           int num1;
           if(!Int32.TryParse(TextBox1.Text, out num1))
           {
              Label1.Text = "Not a valid number";
              return;
           }
           int num2;
 
          if(!Int32.TryParse(TextBox2.Text, out num2))
          {
             Label1.Text = "Not a valid number";
             return;
          }
          sum = num1 + num2;
          Label1.Text = sum.ToString();
        }
