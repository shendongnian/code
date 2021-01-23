    using(var context = new XYZContext())
      {   
          context.Database.Connection.Open();
          using (TransactionScope s = context.Connection.BeginTransaction())
          {
                   
              Int32 count = (from xyz in context.XYZs
                               where xyz.Name == "SameName"
                               select xyz.Name).Count();
              Assert.AreEqual(count, 1);
              s.Commit()
            }
       }
