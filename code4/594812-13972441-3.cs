     List<dynamic> lstKnownMoves = dsAttacksTemp.Tables[0].Rows
                              .Cast<DataRow>().Select(r => new 
                                   { 
                                      Column1 = r["Column1"].ToString(),  
                                      Column2 = r["Column2"].ToString(), 
                                      Column3 = r["Column3"].ToString() 
                                   }).ToList<dynamic>();
     foreach(var item in lstKnownMoves) 
          Console.WriteLine("Column1: {0} Column2: {1} Column3: {2}", 
              item.Column1, item.Column2, item.Column3);
