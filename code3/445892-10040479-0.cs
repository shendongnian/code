    var invoices = from invoice in dbContext.eve_Invoices
                   select new
                   {
                     invoice,
                     PersianYear = invoice.DateCreation != null ? >pc.GetYear((DateTime)invoice.DateCreation) : 0,
                     PersianMonth = invoice.DateCreation != null ? >pc.GetDayOfMonth((DateTime)invoice.DateCreation) : 0,
                     PersianDay = invoice.DateCreation != null ? >pc.GetDayOfMonth((DateTime)invoice.DateCreation) : 0
                   };
