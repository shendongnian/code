    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.ColumnIndex ==1) //Assuming the button column as second column, if not can change the index
                {
                    //check if anything needs to be validated here
                    Form1 f = new Form1();
                    f.navId = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    f.Show();
    
                }
            }
