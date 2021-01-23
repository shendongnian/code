    var leadtasktype = _context.LeadTypeTaskTypes.Where(l => l.LeadTypeId == item.Value);
    var newData = leadtasktype;
    
                    foreach(LeadTypeTaskType l in leadtasktype){
                        if (l.TaskTypeId == 21)
                        {
                            newData.Remove(l);
                        }
                    }
