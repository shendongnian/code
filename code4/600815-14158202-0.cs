    public void EditReport(Inspection obj)
    {
        var inspection = new tbl_inspection
        {
            id_inspection = obj.ID,
            code = obj.Code       
        };
    
        foreach (var roll in obj.Rolls)
        {                    
            var rollStub = new tbl_inspection_roll
            {
                id_inspection_roll = roll.ID,
                id_inspection = obj.ID,
                description = roll.Description
            };
    
            container.tbl_inspection_roll.Attach(roll);
            container.ObjectStateManager.ChangeObjectState(roll, (roll.id_inspection_roll == 0) ? EntityState.Added : EntityState.Modified);
        }
    
        container.tbl_inspection.Attach(inspection);
        container.ObjectStateManager.ChangeObjectState(inspection, EntityState.Modified);
    
        container.SaveChanges();
    }
