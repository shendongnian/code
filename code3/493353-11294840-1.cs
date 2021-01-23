    //attach in code or via designer:
    dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
    
        //example implementation:
        void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {  
            if (e.ColumnIndex == Column1.Index && e.Value==null)//where Column1 is your combobox column
            {
                e.Value = "Empty";
            }
        }
