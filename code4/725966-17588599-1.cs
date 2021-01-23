    try{
        Table1 Obj = new Table1();
        Obj.col1 = 2010;
        Obj.col2 =0;
        Obj.col3 = 103907;
        Obj.col4 = 14145;
        DataContext1 dbContext = new DataContext1()
        dbContext.AddToTable1(Obj);      
        dbContext.ObjectStateManager.ChangeObjectState(Obj,System.Data.EntityState.Added);
        dbContext.SaveChanges();
        }
    catch (System.Data.Entity.Validation.DbEntityValidationException e)
        {
            string validationErrors = "DbEntityValidationException ValidationErrors: ";
            foreach (var k in e.EntityValidationErrors)
            {
                foreach (var e1 in k.ValidationErrors)
                {
                    validationErrors += string.Format("{0} - {1}; ", e1.PropertyName, e1.ErrorMessage);
                }
            }
            throw new Exception(validationErrors, e);
        }
