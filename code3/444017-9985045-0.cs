            DataGridViewLinkColumn col1 = new DataGridViewLinkColumn();
            dataGridView1.Columns.Add(col1);
            dataGridView1.Columns[0].Name = "Links";
            DataGridViewRow dgvr = new DataGridViewRow();
            dgvr.CreateCells(dataGridView1);
            DataGridViewCell linkCell = new DataGridViewLinkCell();
            linkCell.Value = @"http:\\www.google.com";
            dgvr.Cells[0] = linkCell;
            dataGridView1.Rows.Add(dgvr);
