	string[] roles = System.Web.Security.Roles.GetRolesForUser();
	var modules = roles
		.SelectMany(r =>
			entity.TblModulsInRoles.Where(m => m.Roles.RoleName == r)
		)
		.Distinct();
