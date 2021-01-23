    for (int i = 0; i < dataGridView2.ColumnCount; i++)
        {
            for (int j = 0; j < dataGridView2.RowCount; j++)
            {
                box = new CheckBox();
                box.Text = "MyDate";
                //box.Size = new System.Drawing.Size(15, 15);
                dataGridView2.Controls.Add(box);
                Rectangle rec = dataGridView2.GetCellDisplayRectangle(i, j, true);
                box.Left = rec.Left;
                box.Top = rec.Top;
                //Added code
                box.Tag = new Point(i,j);
                box.Click += CheckBoxesClicked;
            }
        }
    private void CheckBoxesClicked(object sender, EventArgs e){
       CheckBox chb = sender as CheckBox;
       if(chb.Tag != null) {
          Point coord = (Point)chb.Tag;
          MessageBox.Show(string.Format("Row index: {0}\nColumn index: {1}", coord.Y, coord.X);
       }
    }     
