    int columnOfcustID = 0; // change this to correct custID column index
    int columnOfcontractID = 1; // change this to correct contractID column index
    int columnOftotalpayment = 2; // change this to correct totalpayment column index
    foreach(DataGridViewRow row in DataGridView1.SelectedRows)
    {
        Console.WriteLine(row.Cells(columnOfcustID).Value);
        Console.WriteLine(row.Cells(columnOfcontractID).Value);
        Console.WriteLine(row.Cells(columnOftotalpayment).Value);
    }
