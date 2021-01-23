        bool isChecked = ((CheckBox)row.FindControl("CheckBox1")).Checked;
        if(isChecked)
        {
            for( int j=0;j<n;j++)
            {
                TextBox tbForCell = new TextBox();
                tbForCell.Text = GridView1.Rows[i].Cells[j].Text;
                GridView1.Rows[i].Cells[j].Text = "";
                GridView1.Rows[i].Cells[j].Controls.Add(tbForCell);
            }
        }
