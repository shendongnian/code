    var leadtasktype = _context.LeadTypeTaskTypes.Where(l => l.LeadTypeId == item.Value);
    for (var i = 0; i < leadtasktype.Count; i++)
    {
      if (leadtasktype[i].TaskTypeId == 21)
      {
        leadtasktype.RemoveAt(i);
      }
    }
