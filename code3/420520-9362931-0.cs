    if (dataGridView3.CurrentCell.Value == DBNull.Value)
    {
        MessageBox.Show("Pending");
    }
    else
    {
        MessageBox.Show("Already Paid");
    }
