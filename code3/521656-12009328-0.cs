    private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
    {
        // Use this instead of dataGridView1
        DataGridView dgv = sender as DataGridView;
        if (dgv == null) // Add some checking
        {
            return;
        }
        if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
        {
             //...
