    private void HeapStatsChart_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
            {
                HitTestResult result = HeapStatsChart.HitTest(e.X, e.Y);
                if (result != null && result.Object != null)
                {
                    // When user hits the LegendItem
                    if (result.Object is LegendItem)
                    {
                        // Legend item result
                        LegendItem legendItem = (LegendItem)result.Object;
                        ColorDialog Colour = new ColorDialog();
                        if (Colour.ShowDialog() == DialogResult.OK)
                        {
                            HeapChartColorPref[Convert.ToInt16(legendItem.Name.Substring(4))].color = Colour.Color;
                            GenerateHeapStatsChart(HeapChartColorPref);
                        }
                    }
                }
            }
