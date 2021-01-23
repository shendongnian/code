            private bool DecimalOnly_KeyPress(TextBox txt, bool numeric, KeyPressEventArgs e)
            {
                if (numeric)
                {
                    // Test first character - either text is blank or the selection starts at first character.
                    if (txt.Text == "" || txt.SelectionStart == 0)
                    {
                        // If the first character is a minus or digit, AND
                        // if the text does not contain a minus OR the selected text DOES contain a minus.
                        if ((e.KeyChar == '-' || char.IsDigit(e.KeyChar)) && (!txt.Text.Contains("-") || txt.SelectedText.Contains("-")))
                            return false;
                        else
                            return true;
                    }
                    else
                    {
                        // If it's not the first character, then it must be a digit or backspace
                        if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))
                            return false;
                        else
                            return true;
                    }
                }
                else
                {
                    // Test first character - either text is blank or the selection starts at first character.
                    if (txt.Text == "" || txt.SelectionStart == 0)
                    {
                        // If the first character is a minus or digit, AND
                        // if the text does not contain a minus OR the selected text DOES contain a minus.
                        if ((e.KeyChar == '-' || char.IsDigit(e.KeyChar)) && (!txt.Text.Contains("-") || txt.SelectedText.Contains("-")))
                            return false;
                        else
                        {
                            // If the first character is a decimal point or digit, AND
                            // if the text does not contain a decimal point OR the selected text DOES contain a decimal point.
                            if ((e.KeyChar == '.' || char.IsDigit(e.KeyChar)) && (!txt.Text.Contains(".") || txt.SelectedText.Contains(".")))
                                return false;
                            else
                                return true;
                        }
                    }
                    else
                    {
                        // If it's not the first character, then it must be a digit or backspace OR
                        // a decimal point AND
                        // if the text does not contain a decimal point or the selected text does contain a decimal point.
                        if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || (e.KeyChar == '.' && (!txt.Text.Contains(".") || txt.SelectedText.Contains("."))))
                            return false;
                        else
                            return true;
                    }
                }
            }
