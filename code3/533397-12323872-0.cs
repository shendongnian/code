    Var CCGroups= From c in CCList
                  group c by c.cc into g
    			  select new {CC=g.key, OtherParam= g};
    			  
    Foreach (var g in CCGroups)
      {
    	 Consile.writeline("{0}",g.CC);
    	
         Foreach(var P in g.OtherParam)
    	   {
    		Console.WriteLine{"{0},{1},{2},{3}",P.Descr,P.C_NO,P.Vol,P.Wt}
    	   }
     }
