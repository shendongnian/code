                ColumnItem2.ValueMember = "Display";
                ColumnItem2.DisplayMember = "Display";
              for(int i=0;i<10;i++)// it will add elements to a combox
               {
                   ColumnItem2.Items.Add(i);
                   }
          dataGridView1.Rows.Add();  // add row everytime to add a new combobox to the next row.
             int columncount = dataGridView1.ColumnCount;// count no of coloumns
             int rowcount = dataGridView1.RowCount;;// count no of rows
