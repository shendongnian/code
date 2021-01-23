    public IList<SubGroup> GetPendingSubGroups()
        {
            using(var db=new DataClasses1DataContext())
            {
                var pendingSubGroup = db.sys_Log_Account_SubGroups.Where(subGroup => subGroup.cAuthorizedStatus.Equals("Pending")).Join(db.sys_Account_Primary_Groups, subGroup => subGroup.nGroupCode, group => group.nGroupCode,(subGroup, group) => new SubGroup
                {
                    Name = subGroup.cSubGroupName,
                    AddedBy = subGroup.cAddedBy,
                    AddedOn = subGroup.dAddedOn 
                }).ToList();  
                return pendingSubGroup; 
            }
        }
