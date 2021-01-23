    for(int j=0; j<monthlychart.Rows.Count; j++)
                    {
                        if(monthlychart.Rows[j][4]!=DBNull.Value)
                        {
                            DateTime xvalue = Convert.ToDateTime(monthlychart.Rows[j][4]);
                            double yvalue = Convert.ToDouble(monthlychart.Rows[j][8]);
                            Chart1.Series[plantseries].Points.AddXY(xvalue,yvalue);
                            Chart1.DataBind();
                            
                        }
                    }
