    protected void ItemInsetring(object sender, FormViewInsertEventArgs e)
        {
            FormView fv = sender as FormView;
            foreach (FormViewRow r in fv.Controls[0].Controls)
            {
                foreach (TableCell cell in r.Controls)
                {
                    foreach (TextBox txtin cell.Controls.OfType<TextBox>())
                    {
                        txt.Text = txt.Text.Trim();
                    }
                }
            } 
        }
