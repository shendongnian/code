         private void textbox_TextChanged(object sender, EventArgs e)
         {
                TextBox txtBox = (TextBox)sender;
    
                // Either write your own character/number and focus moving logic here 
                // Or the following
                char ch = txtBox.Text.Trim()[0];
                switch(txtBox.Name){
                    case "textbox1":
                        if(Char.IsDigit(ch))
                            textbox2.focus();
                    break;
                    case "textbox2":
                        if(Char.IsLetter(ch))
                            textbox3.focus();
                    break;
    
                    ... // rest of the cases
                }
         }
