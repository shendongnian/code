                using (var ts = new TransactionScope())
                {
                    // Perform multiple updates
                    using (var ta1 = new tbl1TableAdapter())
                    using (var ta2 = new tbl2TableAdapter())
                    {
                        ta1.Update(yourDataSet.tbl1);
                        ta2.Update(yourDataSet.tbl2);
                    }
                    ts.Complete();
                    yourDataSet.AcceptChanges();
                }
