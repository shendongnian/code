    int xPos = dataGridView1.Width;
    for (int i = 0; i < 4; i++)
    {
       xPos -= dataGridView1[i, 0].Size.Width;
    }
     ...
    comboBoxHeaderCell.Size = dataGridView.Columns[0].HeaderCell.Size;
    comboBoxHeaderCell.Location = new Point(xPos, 0);
    xPos += comboBoxHeaderCell.Size.Width;
