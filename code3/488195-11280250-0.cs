    //Here we use more than one column in the where clause. We start by searching column D, then use the Offset method to check the value of column C.
                var query3 = (from cell in sheet.Cells["d:d"]
                              where cell.Value is double && 
                                    (double)cell.Value >= 9500 && (double)cell.Value <= 10000 && 
                                    cell.Offset(0, -1).GetValue<DateTime>().Year == DateTime.Today.Year+1 
                              select cell);
                Console.WriteLine();
                Console.WriteLine("Print all cells with a value between 9500 and 10000 in column D and the year of Column C is {0} ...", DateTime.Today.Year + 1);
                Console.WriteLine();    
                count = 0;
                foreach (var cell in query3)    //The cells returned here will all be in column D, since that is the address in the indexer. Use the Offset method to print any other cells from the same row.
                {
                    Console.WriteLine("Cell {0} has value {1:N0} Date is {2:d}", cell.Address, cell.Value, cell.Offset(0, -1).GetValue<DateTime>());
                    count++;
                }
