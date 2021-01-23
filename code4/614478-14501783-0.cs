      DateTime OneYearAgo = DateTime.Now.AddYears(-1);
    
      var SelectedObject =
                (from workstation in db.Work_Sites
                 join invoice in db.Invoices.Where(i => i.Invoice_Date <= OneYearAgo)
                       on workstation.id equals invoice.Site_Id into g
                 where g.Any()
                 select workstation).ToList();
