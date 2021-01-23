    private void TrimControlNames()
        {
            if (txtFormula.Text.Trim().Length > 0)
            {
                string formula = txtFormula.Text.Trim();
                string pattern1 = "{[a-zA-Z0-9$_ ]+}"; //to identify control placeholders
                StringBuilder names = new StringBuilder();
                foreach (Match m in Regex.Matches(formula, pattern1))
                {
                    if (m.Value.Contains(" "))
                    {
                        string str = m.Value.Replace(" ", string.Empty); //It is ok to remove like this since control names are not allowed to have spaces.
                        formula = formula.Replace(m.Value, str);
                    }
                }
                txtFormula.Text = formula;
            }
        }
