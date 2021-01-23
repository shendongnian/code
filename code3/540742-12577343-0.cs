            int current = 0;
            int headerCount = grdTransactions.HeaderRow.Cells.Count;
 
            for (current = 0; current < headerCount; current++)
            {
                TableHeaderCell cell = new TableHeaderCell();
                cell.Text = grdTransactions.HeaderRow.Cells[current].Text;
                originalHeaderRow.Cells.Add(cell);
            }
