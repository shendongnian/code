						pt = activePanel.PointToClient(Control.MousePosition);
						ch = activePanel.GetChildAtPoint(pt) as Chart;
						if (ch != null)
						{
							HitTestResult ht = ch.HitTest(e.X, e.Y, false);
							if (ht.ChartElementType == ChartElementType.PlottingArea)
							{
								SetLegendValueText(ht, ch);
							}
						}
        private void SetLegendValueText(HitTestResult ht, Chart ch)
		{
			//Get the datapoint 'x' index value
			int dpIndex = 0;
			if (ht != null)
			{
				switch (ht.ChartElementType)
				{
					case ChartElementType.DataPoint: //Cursor is on a series line
						DataPoint dp = ht.Object as DataPoint;
						if (dp != null)
						{
							dpIndex = ht.PointIndex;
						}
						break;
					case ChartElementType.PlottingArea: //Cursor is somewhere in the plot area of the chart
						dpIndex = (int)ht.ChartArea.CursorX.Position;
						break;
				}
			}
			//Set legend value and legend tooltip
			for (int x = 0; x < ch.Legends.Count; x++) //foreach (Series s in ch.Series)
			{
				if (dpIndex > 0)
				{
					ch.Legends[x].Name = "Legend_" + x;
					ch.Legends[x].CellColumns[0].Text = ch.Series[x].Points[dpIndex - 1].YValues[0].ToString();
					ch.Legends[x].CellColumns[0].ToolTip = ch.Legends[x].CellColumns[0].Text;
				}
			}			
		}
