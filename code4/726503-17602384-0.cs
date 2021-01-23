    int test = 0;
    if (ViewState["count"] != null)
       test = (int)ViewState["count"];
    
    for (int j = 0; j < test; j++)
    {
        TextBox box = new TextBox();
        box.ID = "Textbox" + j;
        textBoxes.Add(box.ID, box);
        TableRow r = new TableRow();
        TableCell c = new TableCell();
        c.Controls.Add(box);
        r.Cells.Add(c);
        table1.Rows.Add(r);
    }
