    private void async_fillgridwithdatatable(DataGridView grid, DataTable table)
    {
    	Func<DataTable, IEnumerable<string>> action = new Func<DataTable, IEnumerable<string>>(UpdateDbAndGetData);
    	action.BeginInvoke(o => grid.Invoke(new Action<IEnumerable<string>>(rows => {
    								grid.Rows.Clear();
    								foreach (string username in rows)
    									grid.Rows.Add(username);	
    							}), 
    		action.EndInvoke(o)));
    }
    
    IEnumerable<String> UpdateDbAndGetData(DataTable table) {
    	var existing = db.GetMemberList();
    	foreach (DataRow row in table.Rows)
    	{
    		var username = row["Q51_1"].ToString();
    		if (!existing.Contains(username))
    		{
    			MyDirHelper ldap = new MyDirHelper(username, "");
    			int acclvl = ldap.GetAccessLevel();
    			tbl_Member newMember = new tbl_Member
    				{
    					username = username,
    					first_name = row["Q9_1"].ToString(),
    					last_name = row["Q9_2"].ToString(),
    					.
    					.
    					.
    					id_accesslevel = db.DB_GetMemberAutoAccessLevelIDByLDAPAccessLevel(acclvl),
    					created_on = DateTime.Now,
    					created_by = db.GetUser(E_Username).id_user,
    					modified_by = db.GetUser(E_Username).id_user,
    					modified_on = DateTime.Now
    				};
    			db.InsertIntoMembersEntity(newMember);
    			if (newMember.id_accesslevel != 1)
    			{
    				if (newMember.id_accesslevel != null)
    				{
    					mail_sendWelcome(newMember.email, newMember.id_accesslevel.Value);
    					db.UpdateMemberWelcomeMailSentDate(newMember.id_member, DateTime.Now);
    				}
    			}
    		}
    		else
    		{
    			tbl_Member existingMember = db.GetMemberByLogin(username);
    
    					existingMember.first_name = row["Q9_1"].ToString();
    					existingMember.last_name = row["Q9_2"].ToString();
    					.
    					.
    					.
    					existingMember.modified_by = db.GetUser(E_Username).id_user;
    					existingMember.modified_on = DateTime.Now;
    
    			db.Save();
    		}
    		yield return username;
    	}
    }
