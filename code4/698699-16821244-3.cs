    List<User> userList = (from c in dt.AsEnumerable()
        	        group c by c.Field<string>("UserName") into gr
                    select 
                    new User { 
                               Username=  gr.Key ,
                               ControlNumbers = 
                               (from x in dt.AsEnumerable()
                               where x.Field<string>("UserName") == gr.Key 
                               select x.Field<int>("ControlNumber")).ToList() 
                              }
                            ).ToList();
