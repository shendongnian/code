    var facReturnList2 = 
        facReturnList.Select(x => 
            new Facility { ID = x.Fac_Name.Substring(0, 6), 
                  Fac_Name = x.Fac_Name.Substring(0, 3) })
            .Distinct(new FacilityEqualityComparer()).ToList();
    return facReturnList2;
