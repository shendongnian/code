    if ((anError.Exception) is FormatException)
    {
        if (dataGridView2.CurrentCell == dataGridView2.CurrentRow.Cells[3])
        {
            MessageBox.Show("Please enter a valid time value" + prevTime);
            dataGridView2.CancelEdit();//Only this works
        }
        if (dataGridView2.CurrentCell == dataGridView2.CurrentRow.Cells[2])
        {
            MessageBox.Show("Please enter a valid date");
            dataGridView2.CancelEdit();//Only this works
        }
    }
 
