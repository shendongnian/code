    			public query(int myYear, int myMonth){
                   DateTime my = new DateTime(myYear,myMonth,0);
                   var context = new MCSSUtility.Entities();
                   return context.FBApis.Where(p => EntityFunctions.CreateDateTime(p.year, p.month, 0, 0, 0, 0)  >= my);
                }
