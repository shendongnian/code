    var rs = from cs in db.CsCustomers
                          from ai in db.ArInvoices
                          where cs.CustomerID == ai.CustomerID &&
                          ai.Kategori != null
                          orderby cs.Unit
                          select new
                          {
                              cs.CustomerID,
                              cs.Unit,
                              cs.Name
                          };
    if(rs != null && rs.Any()) //for the .Count you have to add using System.Linq;
         foreach (var r in rs)
         {
              c = new TableCell();
              c.Text = r.CustomerID;
              c.RowSpan = jk;
              tr.Cells.Add(c);
    
              c = new TableCell();
              c.Text = r.Unit;
              c.RowSpan = jk;
              tr.Cells.Add(c);
    
              c = new TableCell();
              c.Text = r.Name;
              c.RowSpan = jk;
              tr.Cells.Add(c);
         }
    }else{
         //the else part 
    }
