                var query = (from q in cont.DailySales where q.Date.Equals(Date) select q);
                var query2 = (from r in cont.Transactions where r.Date.Equals(Date) select r);
                foreach (var z in query)
                {
                    counter++;
                }
                if (counter>0)
                {
                        foreach (var y in query2)
                        {
                            takings = takings + y.Price;
                            Expenses = Expenses + 0;
                            d.Expenses += 0;
                            d.Takings += y.Price;
                            d.Profit = d.Takings - d.Expenses;
                            d.Date = Date;
                           
                            cont.SubmitChanges(); // ***  left it here but better move it outside the foreach, 
                        }              
