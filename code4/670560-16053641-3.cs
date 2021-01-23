     private void txtValormetrocubico_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar)
                        && !char.IsDigit(e.KeyChar)
                        && e.KeyChar != '.' && e.KeyChar != ',')
                {
                    e.Handled = true;
                }
    
                //check if '.' , ',' pressed
                char sepratorChar='s';
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    // check if it's in the beginning of text not accept
                    if (txtValormetrocubico.Text.Length == 0) e.Handled = true;
                    // check if it's in the beginning of text not accept
                    if (txtValormetrocubico.SelectionStart== 0 ) e.Handled = true;
                    // check if there is already exist a '.' , ','
                    if (alreadyExist(txtValormetrocubico.Text , ref sepratorChar)) e.Handled = true;
                    //check if '.' or ',' is in middle of a number and after it is not a number greater than 99
                    if (txtValormetrocubico.SelectionStart != txtValormetrocubico.Text.Length && e.Handled ==false)
                    {
                        // '.' or ',' is in the middle
                        string AfterDotString = txtValormetrocubico.Text.Substring(txtValormetrocubico.SelectionStart);
                        
                        if (AfterDotString.Length> 2)
                        {
                            e.Handled = true;
                        }
                    }
                }
                //check if a number pressed
    
                if (Char.IsDigit(e.KeyChar))
                {
                    //check if a coma or dot exist
                    if (alreadyExist(txtValormetrocubico.Text ,ref sepratorChar))
                    {
                        int sepratorPosition = txtValormetrocubico.Text.IndexOf(sepratorChar);
                        string afterSepratorString = txtValormetrocubico.Text.Substring(sepratorPosition + 1 );
                        if (txtValormetrocubico.SelectionStart > sepratorPosition && afterSepratorString.Length >1)
                        {
                            e.Handled = true;
                        }
                       
                    }
                }
    
                
            }
