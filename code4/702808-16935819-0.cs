    LegendItem legendItem = new LegendItem();
    LegendCell cell1 = new LegendCell();
    cell1.Name = "cell1";
    cell1.Text = "legend text";
    // here you can specify alignment, color, ..., too
    LegendCell cell2 = new LegendCell();
    cell2.Name = "cell2";
    cell2.CellType = System.Windows.Forms.DataVisualization.Charting.LegendCellType.Image;
    cell2.Image = "path of your img";
    cell2.Size = new Size(.....);
    legendItem.Cells.Add(cell1);
    legendItem.Cells.Add(cell2);
