    // Note: Using DataGridView[int col, int row] syntax
    int sum = 0;
    for (int i = 0; i < 3; i++)
    {
        if (dataGridView1[1,i].Value != null)
            sum += int.Parse(dataGridView1[1,i].Value.ToString());
    }
    dataGridView1[1,3].Value = sum;
