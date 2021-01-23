    [Invoke]
    public bool DeleteInspection(Guid ID)
    {
        bool bResult = false;
        // get the inspection to delete
        Inspection inspection = this.ObjectContext.Inspections.Where(a=>a.ID == ID).FirstOrDefualt();
        // first delete all attached entities
        foreach (InspectionItem item in inspection.Items)
        {
            this.ObjectContext.DeleteObject(item);
        }
        // save changes
        this.ObjectContext.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
        // then delete item itself
        this.ObjectContext.DeleteObject(inspection);
        // set result to true only if at least one record has been effected
        if (this.ObjectContext.SaveChanges(SaveOptions.AcceptAllChangesAfterSave) >0)
            bResult = true;
        return bResult;        
    }
