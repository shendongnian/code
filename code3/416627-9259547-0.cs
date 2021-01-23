    // Generic Repository class
    public virtual IQueryable<T> AllForTenant(
        IQueryable<Tuple<T, int>> objectToTenentRelationIds, string objectType)
    {
        var tenantObjects =
            from tenantRelationRecord in objectTenantRelationRepo.All()
            where tenantRelationRecord.TenantId == Global.TenantId
            where tenantRelationRecord.ObjectTypeId == type.TypeId
            select tenantObjectRecord;
            
        var result =
            from item in this.context.GetTable<T>()
            join objectToTenentRelationId in objectToTenentRelationIds
                on objectToTenentRelationId.Item1 equals item
            join tenantObject in tenantObjects
                on objectToTenentRelationIds.Item2 equals tenantObject.ObjectId
            select item;
        return result;
    }
