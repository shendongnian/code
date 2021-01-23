    var requestGuid = Request.Params["GUID"];
    
    if (string.IsNullOrEmpty(requestGuid))
    {
        throw new InvalidOperationException("The request GUID is missing from the URL");
    }
    
    Guid guid;
    
    if (!Guid.TryParse(requestGuid, out guid))
    {
        throw new InvalidOperationException("The request GUID in the URL is not correctly formatted");
    }
    
    using(var connection = new SqlConnection("connection_string"))
    {
        using(var command = new SqlCommand("spSurveyAnswer_Insert", connection))
        {
            command.CommandType = CommandType.StoredProcedure;        
            command.Parameters.AddWithValue("firstParamName", selectValue1);
            command.Parameters.AddWithValue("feedbackParamName", txtFeedBack.Text);
            command.Parameters.AddWithValue("guidParamName", guid);
        
            command.Connection.Open();
            command.ExecuteNonQuery();
        }
    }
