    void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //
            // Do something on double click, except when on the header.
            //
            if (e.RowIndex == -1)
            {
        	//this is row header...
                some code here.
            }
           Code...
        }
