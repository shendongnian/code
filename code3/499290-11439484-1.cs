    IEnumerable<int> charaFilters = CharacFilter.Select(cf => cf.Id);
    e.QueryableSource = _dataContext.Activities.Where(ac => 
        ac.UserId == _userId && 
        ac.ResubmissionDate <= EntityFunctions.TruncateTime(_to) && 
        ac.Priority <= (int)_prio && 
        ac.CompletedDate == null &&
        ac.Characteristics.Any(acc => characFilters.Contains(acc.CharacteristicId)));
