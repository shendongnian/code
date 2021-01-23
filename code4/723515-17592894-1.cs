                var table = TableAdapter.GetData().Select(s => new { s.Index })
                                      .AsEnumerable()
                                      .Select((s, counter) => new
                                      {
                                          s.Index,
                                          counter = counter + 1
                                         
                                      });
                foreach (var item in table)
                {
                    if (item.Index == Emp_ID)
                    {                        
                        //do something
                        break;
                    }
                }
