    private void CompanyViewModel_DeletingRecord(object sender, System.ComponentModel.CancelEventArgs e)
    {
    	App.HandleRecordDeleting(sender, e);
    }
    
    private void CompanyViewModel_DiscardingChanges(object sender, DiscardingChangesEventArgs e)
    {
    	App.HandleDiscardingChanges(sender, e);
    }
