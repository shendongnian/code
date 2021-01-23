            int row = dataGridView1.RowCount;
            string tr="Do not Change";
            for (int i = 0; i < row-1; i++)
            {
                if(dataGridView1[2,i].Value.ToString().Contains(tr))
                {
                    dataGridView1[2, i].ReadOnly = true;
                }
            }
