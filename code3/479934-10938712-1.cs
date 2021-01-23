    foreach (DataGridViewRow r in dataGridView1.Rows)
    {
        if (r.Cells["CheckBox"].Value != null && (bool)r.Cells["CheckBox"].Value)
        {
            foreach (DataGridViewCell c in r.Cells)
            {
                if (c.ValueType == typeof(string))
                {
                    // The code here is still ugly - there is almost certainly
                    // a better design for what you are trying to do but that is
                    // beyond the scope of the question.
                    // Plus it still has your original bug of referencing the 
                    // same row of text boxes repeatedly.
                    TextBox theText1 = (TextBox)vobj.Controls[c.ColumnIndex];
                    theText1 += c.Value.ToString();
                }
            }
        }
    }
