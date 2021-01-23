    if (!int.TryParse(strNumber, out result))
                {
                    errorProvider.SetError(tbNumber, "Only Integers are allowed");
                }
                else
                {
                    errorProvider.Clear();
                }
