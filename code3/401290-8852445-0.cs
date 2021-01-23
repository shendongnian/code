    private DialogResult CheckForSireRestrictionInSubGroup(bool deletingGroup,string currentId)
    {
        if (searchAllSireList)
		    return DialogResult.No;
        
		DataAccessDialog dlg = BeginWaitMessage();
		bool isClose = false;
		
		try
		{
			ISireGroupBE sireGroupBE = sireController.FindSireGroupSearch();
			if (sireGroupBE == null)
			    return DialogResult.No;
		
			//if the current group is in fact the seach group before saving
			bool currentGroupIsSeachGroup = sireGroupBE.TheSireGroup.id == currentId; 
			//if we have setting this group as search group
			bool selectedAsSearchGroup = this.chkBoxSelectedSireGroup.Checked;
			//if the group we currently are in is not longer the seach group(chk box was unchecked)
			bool wasSearchGroup = currentGroupIsSeachGroup && !selectedAsSearchGroup;
			//if the group is becoming the search group
			bool becomesSearchGroup = !currentGroupIsSeachGroup && selectedAsSearchGroup;
			//if the group being deleted is in fact the search group
			bool deletingSearchGroup = deletingGroup && currentGroupIsSeachGroup;
			//if the user checked the checkbox but he's deleting it, not a so common case, but
			//we shouldn't even consider to delete sire in this case
			bool deletingTemporarySearchGroup = deletingGroup && !currentGroupIsSeachGroup;         
			//if we are not deleting a temporary search group and it's either
			//becoming one (without deleting it) or we already are the search group
			bool canDeleteSires = !deletingTemporarySearchGroup && 
								  (becomesSearchGroup || currentGroupIsSeachGroup);
			
			ArrayList deletedSire = new ArrayList();
			
			//we only delete sires if we are in search group
			if (canDeleteSires)
			{   
				if (deletingSearchGroup || wasSearchGroup)
				{
					// If we deleted all sires
					deletedSire.AddRange(sireGroupBE.SireList);
				}
				else
				{
					//if we delete a few sire from the change of search group
					deletedSire = GetDeleteSire(sireGroupBE.SireList);
				}
			}
			EndWaitMessage(dlg);
			isClose = true;
			return ShowSubGroupAffected(deletedSire);
		}
		finally
		{
			if (!isClose)
			{
				EndWaitMessage(dlg);
			}
		}
		return DialogResult.No;
    }
