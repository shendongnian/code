    List<TypeOfDm> dmList; // <=== Declare dmList outside of block statements.
    if (intval == 0) { // <=== Use "==" for comparision, "=" is assignement.
        dmList = datacontext.Trk
            .Where(dm =>  dm.ID == 0)
            .ToList();
    } else { 
        dmList = datacontext.Trk
            .Where(dm =>  dm.ID != 0)
            .ToList();
    } 
    if (dmList.Count != 0) { 
      // do something 
    } 
