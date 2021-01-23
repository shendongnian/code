                    //DataTable initialisation
                    dt = new DataTable();
                    dt.Columns.Add("Column1");
                    dt.Columns.Add("Column2");
                    dt.Columns.Add("Column3");
                    
        
                    dt.Rows.Add(new object[] { DateTime.Parse("6/10/2012 10:10"), 1, 0.1 });
                    dt.Rows.Add(new object[] { DateTime.Parse("6/10/2012 10:20"), 1, 0.1 });
                    dt.Rows.Add(new object[] { DateTime.Parse("6/10/2012 11:05"), 2, 0.1 });
                    dt.Rows.Add(new object[] { DateTime.Parse("6/10/2012 11:06"), 2, 0.1 });
                    dt.Rows.Add(new object[] { DateTime.Parse("6/10/2012 11:07"), 2, 0.1 });
                    dt.Rows.Add(new object[] { DateTime.Parse("6/10/2012 11:08"), 2, 0.1 });
                    dt.Rows.Add(new object[] { DateTime.Parse("6/10/2012 11:09"), 2, 0.1 });
                    dt.Rows.Add(new object[] { DateTime.Parse("6/10/2012 11:10"), 2, 0.1 });
                    dt.Rows.Add(new object[] { DateTime.Parse("6/10/2012 11:11"), 2, 0.1 });
                    dt.Rows.Add(new object[] { DateTime.Parse("6/10/2012 11:12"), 2, 0.1 });
                    dt.Rows.Add(new object[] { DateTime.Parse("6/10/2012 11:13"), 2, 0.1 });
    
    //Method that groups data
        void GroupByDate()
        {
                    DateTime startDate = DateTime.Parse(dt.Rows[0].ItemArray[0].ToString());
                    DateTime endDate = DateTime.Parse(dt.Rows[dt.Rows.Count - 1].ItemArray[0].ToString());
                    StringBuilder sb = new StringBuilder();
                    int rowIndex = 0;
                    for (DateTime d = startDate.AddMinutes(-(startDate.Minute - 1) % 10); rowIndex < dt.Rows.Count && d < endDate.AddMinutes(10 - endDate.Minute % 10); d = d.AddMinutes(10))
                    {
                        double sum = 0;
                        DateTime lastDateInSequence = new DateTime();
                        for (DateTime md = d;rowIndex < dt.Rows.Count && md < d.AddMinutes(10); md = md.AddMinutes(1))
                        {
                            DateTime inbetween = DateTime.Parse(dt.Rows[rowIndex].ItemArray[0].ToString());
                            if ( inbetween == md)
                            {
                                sum += double.Parse(dt.Rows[rowIndex].ItemArray[2].ToString());
                                lastDateInSequence = md;
                                rowIndex++;
                            }
                        }
                        if (sum > 0.0)
                        {
                            // you can add this results to the new DataTable like dt1.Rows.Add(lastDateInSequence.ToString("dd/MM hh:mm"), dt.Rows[rowIndex - 1].ItemArray[1], sum);
                            sb.Append(lastDateInSequence.ToString("dd/MM hh:mm") + " " + dt.Rows[rowIndex - 1].ItemArray[1].ToString() + " " + sum.ToString() + Environment.NewLine);
                        }
                    }
                    MessageBox.Show(sb.ToString());
        }
