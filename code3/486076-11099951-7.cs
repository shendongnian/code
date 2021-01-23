    StringBuilder constrains = new StringBuilder();
    AppendConstrain(contrains, "RAUMKLASSE_ID", RAUMKLASSE_ID);
    AppendConstrain(contrains, "GEBAEUDE_ID", GEBAEUDE_ID);
    AppendConstrain(contrains, "STADT_ID", STADT_ID);
    AppendConstrain(contrains, "REGION_ID", REGION_ID);
    
    StringBuilder query =
        new StringBuilder("SELECT r.BEZEICHNUNG AS BEZEICHNUNG, r.ID AS ID FROM RAUM r");
    
    if (constrains.Length > 0)
    {
        query.Append(" WHERE ");
        query.Append(constrains);
    }
    using (SqlCommand cmd = new SqlCommand(query.ToString(), con))
    {
        // Your code...
    }
