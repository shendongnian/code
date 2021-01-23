                bool loop = true;
                while (loop)
                {
                    loop = false;
                    foreach (var element in chartSettlingCurve.ChartAreas[0].AxisX.StripLines)
                    {
                        if (element.Tag.ToString() == "end")
                        {
                            chartSettlingCurve.ChartAreas[0].AxisX.StripLines.Remove(element);
                            loop = true;
                            break;
                        }
                    }
                }
