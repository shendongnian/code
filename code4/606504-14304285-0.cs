        private void l6_Validating(object sender, CancelEventArgs e)
        {
            int isNumber = 0;
            if (l6.Text.Trim().Length > 0)
            {
                if (!int.TryParse(l6.Text, out isNumber))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(l6, "Svp choisir un nombre entre 2 et 10 ...";);
                }
                else
                {
                    errorProvider1.SetError(l6, "");
                }
            }
        }
    }
