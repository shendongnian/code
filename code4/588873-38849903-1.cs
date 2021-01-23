    for (int row = 1; row <= totalRows; row++)
    {
        for (int col = 0; col < totalCols; col++)
        {
            if (GridView1.Columns[col].Visible)
            {
                if (String.IsNullOrEmpty(GridView1.Rows[row - 1].Cells[col].Text))
                {
                    if (GridView1.Rows[row - 1].Cells[col].Controls[1].GetType().ToString().Contains("Label"))
                    {
                        Label LB = (Label)GridView1.Rows[row - 1].Cells[col].Controls[1];
                        workSheet.Cells[row + 1, col + 1].Value = LB.Text;
                    }
                    else if (GridView1.Rows[row - 1].Cells[col].Controls[1].GetType().ToString().Contains("LinkButton"))
                    {
                        LinkButton LB = (LinkButton)GridView1.Rows[row - 1].Cells[col].Controls[1];
                        workSheet.Cells[row + 1, col + 1].Value = LB.Text;
                    }
                }
                else
                {
                    workSheet.Cells[row + 1, col + 1].Value = GridView1.Rows[row - 1].Cells[col].Text;
                }
