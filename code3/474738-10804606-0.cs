    private void ValidateCollectionChangedEventArgs(NotifyCollectionChangedEventArgs e)
    {
    	switch (e.Action)
    	{
    		case NotifyCollectionChangedAction.Add:
    		{
    			if (e.NewItems.Count != 1)
    			{
    				throw new NotSupportedException(SR.Get("RangeActionsNotSupported"));
    			}
    			break;
    		}
    		case NotifyCollectionChangedAction.Remove:
    		{
    			if (e.OldItems.Count != 1)
    			{
    				throw new NotSupportedException(SR.Get("RangeActionsNotSupported"));
    			}
    			if (e.OldStartingIndex < 0)
    			{
    				throw new InvalidOperationException(SR.Get("RemovedItemNotFound"));
    			}
    			break;
    		}
    		case NotifyCollectionChangedAction.Replace:
    		{
    			if (e.NewItems.Count != 1 || e.OldItems.Count != 1)
    			{
    				throw new NotSupportedException(SR.Get("RangeActionsNotSupported"));
    			}
    			break;
    		}
    		case NotifyCollectionChangedAction.Move:
    		{
    			if (e.NewItems.Count != 1)
    			{
    				throw new NotSupportedException(SR.Get("RangeActionsNotSupported"));
    			}
    			if (e.NewStartingIndex < 0)
    			{
    				throw new InvalidOperationException(SR.Get("CannotMoveToUnknownPosition"));
    			}
    			break;
    		}
    		case NotifyCollectionChangedAction.Reset:
    		{
    			break;
    		}
    		default:
    		{
    			throw new NotSupportedException(SR.Get("UnexpectedCollectionChangeAction", new object[]
    			{
    				e.Action
    			}));
    		}
    	}
    }
