    public List<ThanhToan> ListInvoices(DateTime tuNgay, DateTime denNgay)
    {
        var query = from i in db.Invoices 
                    where i.Date >= tuNgay && i.Date <= denNgay
                    group i by i.Date into g
                    select new ThanhToan {
                        date = Convert.ToDateTime(g.Key), 
                        Total = Convert.ToDouble(g.Sum(s => s.ExtendedCost))
                    };
        return query.ToList();
    }
