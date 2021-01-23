    return this.Json((from r in db.Personnel
                                      join per in db.PersonnelEmployee on r.Id equals per.Personnel_Id
                                      where r.First_Name.ToLower().Contains(term.ToLower()) | r.Last_Name.ToLower().Contains(term.ToLower()) | (r.First_Name.ToLower() + " " + r.Last_Name.ToLower()).Contains(term.ToLower())
                                      join dep in db.RefDepartment
                                      .Where(x => x.DeptDesc != null || x.DeptDesc == null) on per.Department equals dep.Department into rfdp
                                      from g in rfdp.DefaultIfEmpty()
                                      select new { 
                                          firstname = r.First_Name,
                                          lastname = r.Last_Name, 
                                          department = (g == null) ? "None" : g.DeptDesc,
                                          per.Personnel_Id, 
                                          per.Pernr }).ToArray(), JsonRequestBehavior.AllowGet);
