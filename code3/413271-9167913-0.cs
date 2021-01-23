    public void InsertOrReferenceExisting(string data, List<Table1> table1References)
    {
        using (var myEntities = new MyEntities())
        {
            var tbl2 = myEntities.Table2.CreateObject();
            tbl2.Data = data;
            myEntities.Table2.AddObject(tbl2);
            foreach (var row in table1References)
            {
                var tbl1 = myEntities.Table1.Where(x => x.Name == row.Name).FirstOrDefault();
                if (tbl1 == null)
                {
                    tbl1 = myEntities.Table1.CreateObject();
                    tbl1.Name = row.Name;
                }
                    
                tbl2.Table1.Add(tbl1);
            }
            myEntities.SaveChanges();
        }
    }
