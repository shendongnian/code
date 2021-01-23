    string[] lines = System.IO.File.ReadAllLines("your taext file");
        
           var Groups =( 
                    from w in lines 
                    group w by w[0] into g 
                    select new { FirstLetterLine = g.Key, Lins = g }); 
