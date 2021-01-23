                List<DateTime> dates = new List<DateTime>();
                dates.Add(DateTime.Parse("9/11/2001 1:00 PM"));
                dates.Add(DateTime.Parse("9/11/2001 10:00 AM"));
                dates.Add(DateTime.Parse("9/11/1002 3:00 PM"));
                DateTime dateComp = DateTime.Parse("9/11/2001 11:00 AM");
                DateTime? dateClosest = null;
                foreach (DateTime dt in dates)
                {
                    if (dateClosest == null) dateClosest = dt;
                    else
                    {
                        if( (dateComp.Subtract(dt).TotalMilliseconds) <
                             dateComp.Subtract((DateTime)dateClosest).TotalMilliseconds)
                        {
                            dateClosest = dt;
                        }
                    }
                }
