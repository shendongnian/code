    var query = (from zam in pg.Zamow 
                 join skany in zam.NUMBER equals skany.NUMBER
                 where zam.Rok == 2012 
                 select new ViewZamowAndSamSkany
                 {
                     Data = zam.Data,
                     Proforma = zam.Proforma
                 }).Take(100);
    
    MyList = new BindingList<ViewZamowAndSamSkany>(query.ToList());
    zamowBindingSource.DataSource = MyList;
