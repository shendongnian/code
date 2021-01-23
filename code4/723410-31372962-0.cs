    using (var transaction = objectContext.Connection.BeginTransaction())
        {
            foreach (tblTest entity in saveItems)
            {
                this.context.Entry(entity).State = System.Data.EntityState.Added;
                this.context.Set<tblTest>().Add(entity);
                anotherTest.tblTest = entity;
                ....
            }
        }
