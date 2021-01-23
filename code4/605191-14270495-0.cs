    new Form {
        Controls = {
            new TableLayoutPanel {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                Controls = {
                    new Button {Text = "0,0", Dock = DockStyle.Fill},
                    new Button {Text = "1,0", Dock = DockStyle.Fill},
                    new Button {Text = "0,1", Dock = DockStyle.Fill},
                    new Button {Text = "1,1", Dock = DockStyle.Fill}
                },
                RowStyles = {
                    new RowStyle(SizeType.Percent) {Height = 1},
                    new RowStyle(SizeType.Percent) {Height = 1}
                },
                ColumnStyles = {
                    new ColumnStyle(SizeType.Percent) {Width = 1},
                    new ColumnStyle(SizeType.Percent) {Width = 1}
                }
            }
        }
    }.ShowDialog();
