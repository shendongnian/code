     protected void Button1_Click(object sender, EventArgs e)
     {
          string original_text=GetOriginalTextOfTextBox1();
          if(TextBox1.Text==original_text)
          {
               //the text didn't change
          }
          else
          {
               //the text changed. need to update the transaction table and the user table.
          }
          string originaltext2=GetOriginalTextOfTextBox2();
          if(TextBox2.Text==originaltext2)
          {
               //the text didn't change
          }
          else
          {
               //the text changed. need to update the transaction table and the user table.
          }
     }
     protected string GetOriginalTextOfTextBox1()
     {
         //code here that gets the original value of TextBox1 from the User table.
     }
     protected string GetOriginalTextOfTextBox2()
     {
          //code here that gets the original value of TextBox2 from the User table.
     }
