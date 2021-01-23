            var sqlConn = new SqlConnection(@"Data Source=(local)\SQLExpress; Initial Catalog=Test; Integrated Security=True");
            var sqlConn2 = new SqlConnection(@"Data Source=(local)\SQLExpress; Initial Catalog=Test2; Integrated Security=True");
            var parent = SqlSyncDescriptionBuilder.GetDescriptionForTable("Users", sqlConn);
            var child = SqlSyncDescriptionBuilder.GetDescriptionForTable("UsersRoles", sqlConn);
            var parentPKColumns = new Collection<string> {"UserId"};
            var childFKColumns = new Collection<string> {"UserId"};
            child.Constraints.Add(new DbSyncForeignKeyConstraint("FK_UsersRoles_Users", "Users", "UsersRoles", parentPKColumns, childFKColumns));
            
            var fKTestScope= new DbSyncScopeDescription("FKTestScope");
            
            fKTestScope.Tables.Add(parent);
            fKTestScope.Tables.Add(child);
            var scopeProvisioning = new SqlSyncScopeProvisioning(sqlConn2, fKTestScope);
            scopeProvisioning.Apply();
