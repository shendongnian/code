    .GroupBy(x =>  x.co.Name.Contains(HaveCompany ? Company : co.Name)  ? 1 :
      x.b.Name.Contains(HaveCompany ? Company : b.Name) ? 2 :
      x.gen.Name.Contains(HaveCompany ? Company : gen.Name) ? 3 :
      0
    )
    .SelectMany(g =>
    g.Key == 1 ? g.Select(x => new {
      CompanyID = x.co.ID,
      BillTo = x.b,
      Generator = x.gen,
      Name = co.Name
    } :
    g.Key == 2 ? g.Select(x => new {
      CompanyID = co.ID,
      BillTo = b,
      Generator = (Generator) null,
      Name = co.Name
    } :
    g.Key == 3 ? g.Select(x => new {
      CompanyID = co.ID,
      BillTo = (BillTo) null,
      Generator = gen,
      Name = co.Name
    } :
    g.Where(x => false)
    )
