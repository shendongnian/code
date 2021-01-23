     var random = new Random();
                                foreach (DataRow row in dt.Rows)
                                {
                                    var color = String.Format("#{0:X6}", random.Next(0x1000000));
                                    SpecificTestsRapp.PieChartValues.Add(new AjaxControlToolkit.PieChartValue
                                    {
                                        Category = row["TestName"].ToString(),
                                        Data = Convert.ToDecimal(row["Counts"]),
                                        PieChartValueColor = color
                                    });
                                }
                                SpecificTestsRapp.ChartTitle = "Specific Tests Run";
