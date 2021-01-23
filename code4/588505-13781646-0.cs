    int count = tableLayoutPanel1.Controls.Count;
    int newColumn = count % 2;
    int newRow = count / 2;
    if (newRow >= tableLayoutPanel1.RowCount) {
        tableLayoutPanel1.RowCount++;
        // Set appropriate row style
        tableLayoutPanel1.RowStyles.Add(new RowStyle { SizeType = SizeType.AutoSize });
    }
    var newControl = new Button { Dock = DockStyle.Fill };
    tableLayoutPanel1.Controls.Add(newControl, newColumn, newRow);
