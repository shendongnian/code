        //prevent letters, special chars, punctuation, symbols, white spaces
        private void txtType1_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (char.IsLetter(e.KeyChar) ||
                    char.IsSymbol(e.KeyChar) ||
                    char.IsWhiteSpace(e.KeyChar) ||
                    char.IsPunctuation(e.KeyChar))
                    e.Handled = true;
            }
                  
            {
                //allows only numbers between 1 and 100
                string value = txtType1.Text;
                if (txtType1.Text !="")
                    
                {
                    if (Int16.Parse(value) < 1 )
                    {
                        txtType1.Text = ""; 
                    }
                    else if (Int16.Parse(value) > 100)
                    {
                        txtType1.Text = "";
                    }
                   
                    }
                }
            }
       
