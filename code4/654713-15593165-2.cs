     public void Form1_Load(object sender, EventArgs e)
     {  
      there is some code of constructor here
	.....
	dataGridView1.CellContentDoubleClick+=new DataGridViewCellEventHandler(dataGridView1_CellContentDoubleClick);
	......
     }
      void dataGridView3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CellCopy();
        }
 
         /// <summary>
        /// Copy the current value in the buffer
        /// </summary>
        public void CellCopy()
        {
            DataGridViewCell cell = dataGridView1.CurrentCell;
            if (cell != null)
            {
                DataGridViewColumn col = dataGridView1.Columns[cell.ColumnIndex];
                if (col is DGW_NewCellsColumn)
                {
                    if (cell.IsInEditMode)
                    {
                        TextBox txt = dataGridView1.EditingControl as TextBox;
                        if (txt != null)
                            txt.Copy();
                    }
                    else
                    {
                        string val = cell.FormattedValue == null ? "" :  cell.FormattedValue.ToString();
                        if (val == "")
                            Clipboard.Clear();
                        else
                            Clipboard.SetText(val);
                    }
                }
            }
        }
 
