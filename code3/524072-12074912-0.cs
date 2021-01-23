    foreach (LiabilityCheckpointInstance ci in value)
    {
        var tr = new TableRow();
        var tc = new TableCell { Text = ci.CheckGroup };
        tr.Cells.Add(tc);
        tc = new TableCell { Text  = ci.IxCheck.ToString() };
        tr.Cells.Add(tc);
        tc = new TableCell { Text = ci.CheckPointInfo.ToString() };
        tr.Cells.Add(tc);
        tc = new TableCell { Text = ci.RejectedBy };
        tr.Cells.Add(tc);
        tc = new TableCell { Text = ci.Role };
        tr.Cells.Add(tc);
        tc = new TableCell { Text = ci.Mistakes.ToString() };
        tr.Cells.Add(tc);
        // YOU NEED TO BUILD THESE UP FRONT SO YOU CAN LOOP THROUGH THE
        // CHILDREN SAFELY BELOW
        tr.Cells.Add(new TableCell());
        tr.Cells.Add(new TableCell());
        tr.Cells.Add(new TableCell());
        // I DON'T KNOW IF YOUR PROPERTY IS NAMED LiabilityAssignments OR NOT
        // SO REPLACE THAT WITH WHAT EVER IS NECESSARY - BUT IT SHOULD BE THE
        // LIST OF LiabilityAssignment ON THE LiabilityCheckpointInstance OBJECT
        foreach (LiabilityAssignment la in ci.LiabilityAssignments)
        {
            tr.Cells[6].Text = la.LiabileOrganizationName;
            tr.Cells[7].Text = la.LiablePersonName;
            tr.Cells[8].Text = la.Comment;
            ChkpLiabilityDataTable.Rows.Add(tr);
        }
    }
