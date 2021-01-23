	var sql = @"
	WITH BusinessUnitHierarchy ( BusinessUnitID, BusinessName, ParentBusinessUnitID )
	AS(
		Select bu.BusinessUnitID, bu.BusinessName, bu.ParentBusinessUnitID
		from BusinessUnit bu
		inner join [UserPermissions] up on bu.BusinessUnitID = up.BusinessUnitID
		where up.UserID = @userID
		UNION ALL
		Select
		bu.BusinessUnitID, bu.BusinessName, bu.ParentBusinessUnitID
		from BusinessUnit bu
		inner join BusinessUnitHierarchy buh on bu.ParentBusinessUnitID = buh.BusinessUnitID
	)
    SELECT * FROM BusinessUnitHierarchy buh
	";
	context.Database.SqlQuery<BusinessUnit>(sql, new SqlParameter("userID", [[your user ID here]]));
