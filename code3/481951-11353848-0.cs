    public override void SubmitChanges(System.Data.Linq.ConflictMode failureMode)
    {
    	ChangeSet changeset = GetChangeSet();
    	foreach (var change in changeset.Updates.OfType<ARReport>())
    	{
    		// serialize ReportDetails here before submitting changes. 
    	}	
    	try
    	{
    		base.SubmitChanges(ConflictMode.ContinueOnConflict);
    	}
    	catch (ChangeConflictException cce)
    	{
    		// handle this
    	}
    }
