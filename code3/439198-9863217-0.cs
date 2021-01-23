	public IEnumerable<RoleAreasModel> GetRolesWithRoleAreasModelByUserGUID(Guid guid)
	{
		foreach (AspnetRolesRecord role in GetByUserGUID(guid))
		{
			RoleAreasRecord roleAreaRecord = RoleAreasService.Instance.GetRecord(RoleAreasRecord.Fields.ID, role.ID);
			yield return new RoleAreasModel(roleAreaRecord.Area, new RolesMapper().MapToModel(role), getAreaControllersData(roleAreaRecord.ID));
		}
	}
