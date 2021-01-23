    public void MyObj_Save(MyObj myobj, List<OtherObj> otherObjList)
    {
        DbContext.Entry(myobj).State = EntityState.Added;
        foreach (OtherObj otherObj in otherObjList)
        {
            (((System.Data.Entity.Infrastructure.IObjectContextAdapter)DbContext)
                .ObjectContext)
                .ObjectStateManager
                .ChangeRelationshipState(myobj, otherObj,
                    q => q.OtherObjs, EntityState.Added);
        }
 
        DbContext.SaveChanges();
    }
