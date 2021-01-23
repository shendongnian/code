     protected void Button1_Click(object sender, EventArgs e)
     {
          string original_text=GetOriginalText();
          if(TextBox1.Text==original_text)
          {
               //the text didn't change
          }
          else
          {
               //the text changed. need update the transaction table and the user table.
          }
     }
     protected string GetOriginalText()
     {
         //code here that gets the original value
     }
}
