    for (int i = 0; i < dgTest.Rows.Count; i++)
        {
            var row = dgTest.Rows[i];
            if (row.Cells[0].Value.ToString() == search)
            {
                row.Selected = true;
                row.Visible = true;
            }
            else
            {
                row.Selected = false;
                row.Visible = false;
            }
        }
