     var result = ((from inv in inventry.AsQueryable()
                          join st in stockTransactions.AsQueryable()
                          on inv.Id equals st.Id
                          select new { ID = inv.Id, Title = inv.Title, MovedQuantity = st.MovedQuantity, UnitPrice = st.UnitPrice })
                          .GroupBy(s=>new {s.ID,s.Title})
                          .Select(res=>new {Id=res.Key.ID,Title=res.Key.Title,Sold=transactiontype==1?res.Sum(s=>s.MovedQuantity):0,
                          Revenue=transactiontype==1?res.Sum(s=>s.MovedQuantity*s.UnitPrice):0,
                          Distributed=transactiontype==1?res.Sum(s=>s.MovedQuantity):0})).ToList();
