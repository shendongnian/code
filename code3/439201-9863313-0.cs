    public IEnumerable<RoleAreasModel> GetRolesWithRoleAreasModelByUserGUID(Guid guid)
    {
      return GetByUserGUID(guid).Select( role => 
        {
          var roleAreaRecord = RoleAreasService.Instance.GetRecord(RoleAreasRecord.Fields.ID, role.ID);
          return new RoleAreasModel(roleAreaRecord.Area, new RolesMapper().MapToModel(role),getAreaControllersData(roleAreaRecord.ID)));
        });
    }
