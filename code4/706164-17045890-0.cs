                for (int j = 0; j < chartSettlingCurve.ChartAreas[0].AxisX.StripLines.Count; j++)
                {
                    if (chartSettlingCurve.ChartAreas[0].AxisX.StripLines[j].Tag.ToString() == "end")
                    {
                        chartSettlingCurve.ChartAreas[0].AxisX.StripLines.RemoveAt(j);
                        j--;
                    }
                }
