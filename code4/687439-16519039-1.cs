    tbl1
       .SelectMany (
          u => tbl2, 
          (u, c) => 
             new  
             {
                Col1 = u.Col1, 
                Col2 = c.Col2
             }
       )
