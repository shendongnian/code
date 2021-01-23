    public static void HandleDiscardingChanges(object sender, DiscardingChangesEventArgs e)
    {
    	switch (MessageBox.Show("Save changes?", "Save", MessageBoxButton.YesNoCancel))
    	{
    		case MessageBoxResult.Yes:
    			e.Operation = DiscardingChangesOperation.Save;
    			break;
    		case MessageBoxResult.No:
    			e.Operation = DiscardingChangesOperation.Discard;
    			break;
    		case MessageBoxResult.Cancel:
    			e.Operation = DiscardingChangesOperation.Cancel;
    			break;
    		default:
    			throw new InvalidEnumArgumentException("Invalid MessageBoxResult returned from MessageBox.Show");
    	}
    }
    
    public static void HandleRecordDeleting(object sender, CancelEventArgs e)
    {
    	e.Cancel = MessageBox.Show("Delete current record?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.No;
    }
