    var tabelDetails =(from li in dc.My_table
        join m in dc.Table_One on li.ID equals m.ID
        join c in dc.Table_two on li.OtherID equals c.ID
        where //Condition
    group new { m, li, c } by new
	{
		m.ID,
		m.Name
	} into g
    select new
	{
		g.Key.ID,
		Name = g.Key.FullName,
		sponsorBonus= g.Where(s => s.c.Name == "sponsorBonus").Count(),
		pairingBonus = g.Where(s => s.c.Name == "pairingBonus").Count(),
		staticBonus = g.Where(s => s.c.Name == "staticBonus").Count(),   
		leftBonus = g.Where(s => s.c.Name == "leftBonus").Count(),  
		rightBonus = g.Where(s => s.c.Name == "rightBonus").Count(),  
		Total = g.Count()  //Row wise Total
	}).OrderBy(t => t.Name).ToList();
    tabelDetails.Insert(tabelDetails.Count(), new  //This data will be the last row of the grid
    {
	    Name = "Total",  //Column wise total
	    sponsorBonus = tabelDetails.Sum(s => s.sponsorBonus),
	    pairingBonus = tabelDetails.Sum(s => s.pairingBonus),
	    staticBonus = tabelDetails.Sum(s => s.staticBonus),
	    leftBonus = tabelDetails.Sum(s => s.leftBonus),
	    rightBonus = tabelDetails.Sum(s => s.rightBonus ),
	    Total = tabelDetails.Sum(s => s.Total)
    });
