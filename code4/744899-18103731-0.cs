    for (int i = 0; i <= dgAnalyse.Columns.Count - 1; i++)
                {
                    if (dgAnalyse.Columns[i].Visible == true)
                    {
                        Console.WriteLine(dgAnalyse.Columns[dgAnalyse.Columns[i].DisplayIndex].HeaderText);
                    }
                }
