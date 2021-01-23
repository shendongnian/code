        var p = new Person()
        {
            LastName = "test1111111111",
        };
        var c = new Child()
        {
            Name = "Testchild"
        };
        PersonTest(p, c);
---
        public void PersonTest(Person ob, Child ob2)
        {
            try
            {
                using (var con = new Entities())
                {
                    con.Configuration.AutoDetectChangesEnabled = false;
                    var o = new Person();
                    if (ob.PersonId > 0)
                        o = con.People.Find(ob.PersonId);
                    o.PersonId = ob.PersonId;
                    o.LastName = ob.LastName;
                    if (ob.PersonId == 0)
                        con.People.Add(o);
                    con.ChangeTracker.DetectChanges();
                    con.SaveChanges();
                    i = o.PersonId;
                    var o2 = new Child();
                    if (ob2.ChildrenId > 0)
                        o2 = con.Children.Find(ob.PersonId);
                    o2.PersonId = ob2.ChildrenId;
                    o2.Name = ob2.Name;
                    o2.PersonId = i;
                    if (ob2.ChildrenId == 0)
                        con.Children.Add(o2);
                    con.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
            finally
            {
                con.Configuration.AutoDetectChangesEnabled = true;
            }
        }
