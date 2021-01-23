    public static async Task<bool> ValidateEmail(string email)
    {
        var url = ...
        var queryString = ...
        try
        {
            HttpResponseMessage json = await HttpHelper.PostAsync(url, queryString, null);
            SerializationHelper.DeserializeValidationResponse(json.Result));
        } 
        catch (Exception e)
        {
            return false;
        }
        return true;
    }
