        TableCell tcCheckCell = new TableCell();
        var checkBox = new CheckBox();
        checkBox.CheckedChanged += checkBox_CheckedChanged;
        tcCheckCell.Controls.Add(checkBox);
        gridView.Rows[0].Cells.AddAt(0, tcCheckCell);
 
        void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            //do something: You can use Krishna Thota's Code.
        }
