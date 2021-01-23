     protected void txtSmall_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            GridViewRow r = (GridViewRow)t.NamingContainer;
            Txtchanged(r.RowIndex);
        }
        protected void txtMedium_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            GridViewRow r = (GridViewRow)t.NamingContainer;
            Txtchanged(r.RowIndex);
        }
        private void Txtchanged(int row_index)
        {
            TextBox t1 = (TextBox)GridView1.Rows[row_index].Cells[0].FindControl("txtSmall");
            TextBox t2 = (TextBox)GridView1.Rows[row_index].Cells[0].FindControl("txtMedium");
            TextBox t3 = (TextBox)GridView1.Rows[row_index].Cells[0].FindControl("txtTotal");
            t3.Text = (Convert.ToInt32(t1.Text) + Convert.ToInt32(t2.Text)).ToString();
        }
