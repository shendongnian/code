    int yourStartInt = 6;
    foreach(Control control in YourTableID.Controls)
    {
        if (control is TableRow)
        {
            foreach (Control innerControl in control.Controls)
            {
                if (innerControl != null && innerControl is TableCell)
                {
                    TableCell cell = innerControl as TableCell;
                    cell.Text = yourStartInt.ToString();
                    yourStartInt++;
                }
            }
        }
    }
