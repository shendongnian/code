    for (int row = TableLayoutPanel.RowCount-1; row >= 0; row--) {
        if (row % 2 == 0) { //if even
            for (int column = 0; column < TableLayoutPanel.ColumnCount; column++) {
                PictureBox pictureBox = new PictureBox();
                pictureBox.BackColor = Color.Blue;
                TableLayoutPanel.Controls.Add(pictureBox, column, row);
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.Margin = new Padding(1);
        } else { 
            for (int column = TableLayoutPanel.ColumnCount-1; column >= 0; column--) {
                PictureBox pictureBox = new PictureBox();
                pictureBox.BackColor = Color.Blue;
                TableLayoutPanel.Controls.Add(pictureBox, column, row);
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.Margin = new Padding(1);
        }
    }
        
