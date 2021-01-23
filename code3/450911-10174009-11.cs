    var query = modules.GroupBy( m => m.date)
                       .Select( g => 
                                     new 
                                     { 
                                         y = g.Key, 
                                         xrate = g.FirstOrDefault( x=> x.xrate),
                                         yrate = g.FirstOrDefault( x => x.yrate)
                                     });
