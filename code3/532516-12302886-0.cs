     customers.GroupBy(customer=>customer).  //group by object iyself
            Select(c=>                       //select
                        new  
                        {
                          ID = c.Key.Id,                             
                          Name = c.Key.Name, 
                          Count = (c.Key.Orders!=null)? c.Key.Orders.Count():0
                        }
                   );
