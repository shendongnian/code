    Steema.TeeChart.Styles.Line line1 = new Steema.TeeChart.Styles.Line();
    tChart1.Series.Add(line1);
    line1.fillSampleValues();
    
    Steema.TeeChart.Tools.DragPoint dragPoint1 = new Steema.TeeChart.Tools.DragPoint();
    tChart1.Tools.Add(dragPoint1);
    dragPoint1.Cursor = System.Windows.Forms.Cursors.Hand;
    dragPoint1.Series = line1;
