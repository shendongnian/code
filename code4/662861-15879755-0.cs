                DailySale d = new DailySale();
                var query = (from q in cont.DailySales where q.Date.Equals(Date) select q);
               
                foreach (var z in query)
                {
                    counter++;
                }
                if (counter>0)
                {
                    foreach (var r in query)
                    {
                        
                        r.Takings = r.Takings + (decimal)price; //  here i was using d instead of r
                        r.Profit = r.Takings - r.Expenses;
                    }
                    cont.SubmitChanges(); 
                                             
