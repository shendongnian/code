    if (Char.IsNumber(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
                {
                    MessageBox.Show("Only Char are allowed");
                    e.Handled = true;
                }
