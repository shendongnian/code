    ObjectQuery<Activity> query = _dataContext.Activities.Where(ac => 
        ac.UserId == _userId && 
        ac.ResubmissionDate <= EntityFunctions.TruncateTime(_to) && 
        ac.Priority <= (int)_prio && 
        ac.CompletedDate == null);
    if (characFilters != null)
    {
        query = query.Where(ac => ac.Characteristics
                         .Any(acc => characFilters.Contains(acc.CharacteristicId)));
    }
    e.QueryableSource = query;
