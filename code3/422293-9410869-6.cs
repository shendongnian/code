    foreach (var item in soap.data)
    {
        var educationNames = item.education_history.Select(i => i.name.ToString());
        var ftr = String.Join(",", educationNames);
        
        var previousCompaniesNames = item.work_history.Select(i => i.company_name.ToString());
        var ftr1 = String.Join(",", previousCompaniesNames);
    
        var statement = "INSERT INTO [Snaps] (Loc_city,Loc_state,Loc_country,Edu_Hist1,Work_Hist1) VALUES (@city, @state, @country, @educationNames, @previousCompaniesNames)";
        var command = new SqlCommand(statement, con);
        command.Parameters.Add("@city", SqlDbType.VarChar, 255).Value = item.current_location.city.ToString();
        command.Parameters.Add("@state", SqlDbType.VarChar, 255).Value = item.current_location.state.ToString();
        command.Parameters.Add("@country", SqlDbType.VarChar, 255).Value = item.current_location.country.ToString();
        command.Parameters.Add("@educationNames", SqlDbType.VarChar, 4000).Value = ftr
        command.Parameters.Add("@previousCompaniesNames", SqlDbType.VarChar, 4000).Value = ftr1
        command.ExecuteNonQuery();    
    }
