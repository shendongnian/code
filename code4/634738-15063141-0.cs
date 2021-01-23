    else //if (MachineErrSplit[i].Contains(DBErr))
    {
         Errs_Solved += MachineErrSplit[i] + Seperator;
    }
    
    if (!DBErr.Contains(MachineErrSplit[i]))
    {
         Errs_New += MachineErrSplit[i] + Seperator;
    }
