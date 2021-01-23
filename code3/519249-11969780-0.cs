    var l = chart1.Legends[0];
    l.LegendStyle = LegendStyle.Table;
    l.TableStyle = LegendTableStyle.Tall;
    l.BorderColor = Color.OrangeRed;
    l.Docking = Docking.Bottom;
    l.LegendStyle = LegendStyle.Table;
    l.HeaderSeparator = LegendSeparatorStyle.DashLine;
    l.HeaderSeparatorColor = Color.Red;
    var firstColumn = new LegendCellColumn();
    l.ColumnType = LegendCellColumnType.SeriesSymbol;
    l.CellColumns.Add(firstColumn);
    var secondColumn = new LegendCellColumn();
    l.ColumnType = LegendCellColumnType.Text;
    secondColumn.Text = "#SER";
    l.CellColumns.Add(secondColumn);
    foreach (DataRow row in dt.Rows)
    {
        var column = new LegendCellColumn();
        column.ColumnType = LegendCellColumnType.Text;
        column.HeaderText = row["x"].ToString();
        column.Text = "#VALY";
        l.CellColumns.Add(column);
    }
