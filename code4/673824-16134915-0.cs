     private void textBox_KeyDown(object sender, KeyEventArgs e)
     {
         TextBox textBox = sender as TextBox;
         if(textBox != null)
         {
             if (!String.IsNullOrEmpty(textBox.Text))
             {
                 //get the last character and convert it to a key
                 char prevChar = textBox.Text[textBox.Text.Length - 1];
                 Keys k = (Keys)char.ToUpper(prevChar);
   
                 //compare the Key pressed to the previous Key
                 if (e.KeyData == k)
                 {
                     //suppress the keypress if the key is the same as the previous one
                     e.SuppressKeyPress = true;              
                 }
             }
         }
     }
