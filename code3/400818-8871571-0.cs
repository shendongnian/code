        public void SetColor2(GridViewRow row, string columnName, int cellIndex)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                int number = Convert.ToInt32(columnName);
                if (number == 0)
                {
                    row.Cells[cellIndex].Text = "";
                    return;
                }
                else if ((number > 0) && (number <= 74))
                {
                    row.Cells[cellIndex].BackColor = System.Drawing.Color.Red;
                    row.Cells[cellIndex].ForeColor = System.Drawing.Color.Black;
                    return;
                }
            }
        }
