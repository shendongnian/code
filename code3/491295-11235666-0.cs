        foreach (HtmlTableRow row in MyTable.Rows)
        {
            if (row.Cells[0].TagName.ToLower() == "th")
            {
                // header.
            }
            else
            {
                // cell.
            }
        }
