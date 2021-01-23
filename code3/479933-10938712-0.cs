    for (int col = 1; col < 5; col++)
    {
        TextBox theText1 = (TextBox)vobj.Controls[col - 1];
        // theText1.Text = row[x].Cells[col].Value.ToString();
        theText1.Text = dataGridView1.Rows[x].Cells[col].Value.ToString();
    }
