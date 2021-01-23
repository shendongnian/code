    protected void GridView1_DataBound(object sender, EventArgs e)
        {
            int RowSpan = 2;
            for (int i = GridView1.Rows.Count-2; i >=0 ;i-- )
            {
                GridViewRow currRow = GridView1.Rows[i];
                GridViewRow prevRow = GridView1.Rows[i+1];
                if (currRow.Cells[0].Text == prevRow.Cells[0].Text)
                {
                    currRow.Cells[0].RowSpan = RowSpan;
                    prevRow.Cells[0].Visible = false;
                    RowSpan += 1;
                }
                else
                    RowSpan = 2;
            }
        }
