    List<Employees> emps = new List<Employees>();
            emps.Add(new Employees { PK = 1, Name = "bob" });
            emps.Add(new Employees { PK = 2, Name = "sam" });
            emps.Add(new Employees { PK = 3, Name = "greg" });
            emps.Add(new Employees { PK = 4, Name = "kip" });
            emps.Add(new Employees { PK = 5, Name = "jill" });
            emps.Add(new Employees { PK = 6, Name = "kelly" });
            emps.Add(new Employees { PK = 7, Name = "chris" });
            List<ExpenseTeamMembers> etm = new List<ExpenseTeamMembers>();
            etm.Add(new ExpenseTeamMembers { empPK = 2, ExpMgrPK = 7, PK = 1 });
            etm.Add(new ExpenseTeamMembers { empPK = 5, ExpMgrPK = 7, PK = 2 });
            etm.Add(new ExpenseTeamMembers { empPK = 1, ExpMgrPK = 7, PK = 3 });
            etm.Add(new ExpenseTeamMembers { empPK = 6, ExpMgrPK = 3, PK = 4 });
            etm.Add(new ExpenseTeamMembers { empPK = 4, ExpMgrPK = 3, PK = 5 });
            var query = from t in
                            (
                                from emp in emps
                                join o in etm on emp.PK equals o.empPK into j
                                from k in j.DefaultIfEmpty()
                                select new { Name = k == null ? string.Empty : emp.Name })
                        where t.Name != string.Empty
                        select t.Name;
