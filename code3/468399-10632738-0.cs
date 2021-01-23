    protected void ItemInsetring(object sender, FormViewInsertEventArgs e)
        {
            FormView fv = sender as FormView;
            foreach (FormViewRow r in fv.Controls[0].Controls)
            {
                foreach (TableCell cell in r.Controls)
                {
                    foreach (TextBox c in cell.Controls.OfType<TextBox>())
                    {
                        Response.Write(c.GetType().ToString() + "<br>");
                        c.Text = c.Text.Trim();
                        string text = c.Text;
                    }
                }
            } 
        }
