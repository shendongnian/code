    string raumklasseid = RAUMKLASSE_ID;
            string gebaudeid = GEBAEUDE_ID;
            string stadtid = STADT_ID;
            string regionid = REGION_ID;
            string whereClause = string.Empty;
    
    if (!string.IsNullorEmpty(raumklasseid))
    {
       whereClause = "RAUMKLASSE_ID IN (" + raumklasseid + ")";
    }
    if (!string.IsNullorEmpty(stadtid ))
    {
       if(string.IsNullorEmpty(whereClause)
          whereClause = "STADT_ID IN (" + stadtid + ")";
       else 
          whereClause += "AND RSTADT_ID IN (" + stadtid + ")";
    }
    if (!string.IsNullorEmpty(stadtid ))
    {
       if(string.IsNullorEmpty(whereClause)
          whereClause = "STADT_ID IN (" + stadtid + ")";
       else 
          whereClause += "AND RSTADT_ID IN (" + stadtid + ")";
    }
    if (!string.IsNullorEmpty(regionid))
    {
       if(string.IsNullorEmpty(whereClause)
          whereClause = "REGION_ID IN (" + regionid + ")";
       else 
          whereClause += "AND REGION_ID IN (" + regionid + ")";
    }
    
    if(!string.IsNullorEmpty(whereClause)
    whereClause = "WHERE " + whereClause ;
    
    // now your cmd should be like that
    
    using (SqlCommand cmd = new SqlCommand(@"SELECT r.BEZEICHNUNG AS BEZEICHNUNG, r.ID AS ID FROM RAUM r " + whereClause , con))
