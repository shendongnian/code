            if ( typeof (Int32) == dataGridView1.SelectedCells[0].Value.GetType())
            {
                MessageBox.Show( "DataGridView Cell Value is Numeric" );
            }
            else if (typeof(string) == dataGridView1.SelectedCells[0].Value.GetType())
            {
                MessageBox.Show("DataGridView Cell Value is Alphabetic ");
            }
