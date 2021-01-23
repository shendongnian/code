    public IEnumerable<RoleAreasModel> Foo(Guid id)
    {
       var mapper = new RolesMapper();
       return from role in GetByUserGUID(id)
              let areaRecord = RoleAreasService.Instance.GetRecord(RoleAreasRecord.Fields.ID, role.ID)
              select new RoleAreasModel(areaRecord.Area, mapper.MapToModel(role), getAreaControllersData(areaRecord.ID));
    }
