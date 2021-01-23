    if(rsData.Read()) {
      int index = rsData.GetOrdinal("columnName"); // I expect, just "ursrdaystime"
      if(rsData.IsDBNull(index)) {
         // is a null
      } else {
         // access the value via any of the rsData.Get*(index) methods
      }
    } else {
      // no row returned
    }
