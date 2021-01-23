       ChartGenerator charBartGen = new ChartGenerator();
                charBartGen.ChartCreated += new ChartCreatedEventHandler(charBartGen_ChartCreated);
                charBartGen.CreateBarChart(pictureBox2.Height, pictureBox2.Width,
                    stats.MaxChecks,
                    "Past 7 days",
                    stats.Last7DayChecks1, stats.Last7DayChecks2);
