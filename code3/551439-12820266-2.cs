    var assembled = Enumerable.Range(0, eventIDs.Length).Select(i=> new { id=eventIDs[i], name=invName[i], date=eventDates[i] } );
    foreach(var value in assembled){
        cmd.Parameters.Add(new SqlParameter("@EventID", SqlDbType.Int));
        cmd.Parameters["@EventID"].Value = int.Parse(value.id);
        cmd.Parameters.Add(new SqlParameter("@InvestigatorName", SqlDbType.NVarChar));
        cmd.Parameters["@InvestigatorName"].Value = value.name;
        cmd.Parameters.Add(new SqlParameter("@CopyDate", SqlDbType.DateTime));
        cmd.Parameters["@CopyDate"].Value = Convert.ToDateTime(value.date);
    }
