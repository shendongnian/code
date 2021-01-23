                    //Create the series legend
                    chartSel.Series[ySeries.Name].ChartArea = "ChartArea1";
                    chartSel.Legends.Remove(chartSel.Legends.FindByName("Legend1"));
                    chartSel.Legends.Add(ySeries.Name);
					chartSel.Legends[0].Name = ySeries.Name;
                    //Format the series legend
                    chartSel.Legends[ySeries.Name].Docking = Docking.Right;
                    chartSel.Legends[ySeries.Name].DockedToChartArea = "ChartArea1";
                    chartSel.Legends[ySeries.Name].Alignment = StringAlignment.Near;
                    chartSel.Legends[ySeries.Name].IsDockedInsideChartArea = false;
                    chartSel.Legends[ySeries.Name].LegendStyle = LegendStyle.Table; //.Row;
                    chartSel.Legends[ySeries.Name].TableStyle = LegendTableStyle.Tall;
                    chartSel.Legends[ySeries.Name].IsEquallySpacedItems = false;
                    chartSel.Legends[ySeries.Name].Font = new Font("Segoe UI", 7, FontStyle.Bold);
					//chartSel.Legends[ySeries.Name].TextWrapThreshold = 17; // 19;
                    chartSel.Legends[ySeries.Name].Position.Auto = false;
                    chartSel.Legends[ySeries.Name].Position.X = 80;
                    chartSel.Legends[ySeries.Name].Position.Y = 2;
                    chartSel.Legends[ySeries.Name].Position.Width = 18;
					chartSel.Legends[ySeries.Name].Position.Height = 12;
					//Format series data point value cell
					chartSel.Legends[ySeries.Name].CellColumns.Add(new LegendCellColumn("", LegendCellColumnType.Text, ""));
					chartSel.Legends[ySeries.Name].CellColumns[0].Alignment = ContentAlignment.MiddleLeft; //.TopLeft;
					chartSel.Legends[ySeries.Name].CellColumns[0].Margins = new System.Windows.Forms.DataVisualization.Charting.Margins(10, 10, 1, 1);
					chartSel.Legends[ySeries.Name].CellColumns[0].MinimumWidth = 500;
					chartSel.Legends[ySeries.Name].CellColumns[0].MaximumWidth = 500;
					chartSel.Legends[ySeries.Name].CellColumns[0].BackColor = Color.FromArgb(120, chartSel.Series[ySeries.Name].Color);
                    //Format legend cell spacer
					chartSel.Legends[ySeries.Name].CellColumns.Add(new LegendCellColumn("", LegendCellColumnType.Text, ""));
					chartSel.Legends[ySeries.Name].CellColumns[1].Alignment = ContentAlignment.TopLeft;
					chartSel.Legends[ySeries.Name].CellColumns[1].Margins = new System.Windows.Forms.DataVisualization.Charting.Margins(0, 0, 0, 0);
					chartSel.Legends[ySeries.Name].CellColumns[1].MinimumWidth = 25;
					chartSel.Legends[ySeries.Name].CellColumns[1].MaximumWidth = 25;
					chartSel.Legends[ySeries.Name].CellColumns[1].BackColor = Color.Black;
                    //Format series title cell
                    chartSel.Legends[ySeries.Name].CellColumns.Add(new LegendCellColumn("", LegendCellColumnType.Text, ySeries.Name));
                    chartSel.Legends[ySeries.Name].CellColumns[2].Alignment = ContentAlignment.MiddleLeft;
                    chartSel.Legends[ySeries.Name].CellColumns[2].Margins = new System.Windows.Forms.DataVisualization.Charting.Margins(0, 0, 1, 1);
					chartSel.Legends[ySeries.Name].CellColumns[2].MinimumWidth = 1475; //1500;
					chartSel.Legends[ySeries.Name].CellColumns[2].MaximumWidth = 1475; //1500;
					chartSel.Legends[ySeries.Name].CellColumns[2].ToolTip = ySeries.Name;
