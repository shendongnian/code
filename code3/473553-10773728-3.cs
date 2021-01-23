        void dataGridView1_EditingControlShowing(object sender,
             DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is Button)
            {
                Button btn = e.Control as Button;
                btn.Click -= new EventHandler(btn_Click);
                btn.Click += new EventHandler(btn_Click);
            }
        }
 
        void btn_Click(object sender, EventArgs e)
        {
            int col = this.dataGridView1.CurrentCell.ColumnIndex;
            int row = this.dataGridView1.CurrentCell.RowIndex;
            // Rest of the logic goes here!
        } 
