    for (int j = 0; j < 5; j++)
    {
        HtmlTableRow row = new HtmlTableRow();
        for (int i = 0; i < 3; i++)
        {
            HtmlTableCell cell = new HtmlTableCell();
            RadioButton radioButton = new RadioButton();
            radioButton.Text = "Text " + i.ToString();
            cell.Controls.Add(radioButton);
            row.Cells.Add(cell);
        }
        table1.Rows.Add(row);
    }
