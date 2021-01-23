        Obj GetObj(string primaryKey)
        {
            dataBase context = new dataBase();
              var obj = (from a
                         in context.TableA
                         where a.Id == primaryKey
                         select a);
              var otherObj = (from b
                              in context.TableB
                              where b.Id == a.ForeignKey
                              select b);
             
             Obj foo = new Obj();
             
             foo.Id = a.Id;
             foo.SomethingElse = a.Somthing;
             foo.FromB = b.Id;
             foo.AnInt = (int)b.count;
             return foo;
        }
