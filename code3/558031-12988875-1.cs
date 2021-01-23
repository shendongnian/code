    public GetStackOverflowResponse GetStackOverflow(MySearchSettings searchSettings)
    {
        var response = new GetStackOverflowResponse();
        try
        {
            User user = null;
            if (searchSettings == null)
                throw new ArgumentNullException("searchSettings");
            if (searchSettings.ID.HasValue)
                user = //queryByID;
            else if (!String.IsNullOrEmpty(searchSettings.Name))
                user = //queryByName;
            else if (!String.IsNullOrEmpty(searchSettings.StackOver))
                user = //queryByStackOver;
            response.User = user;
        }
        catch(Exception e)
        {
            response.ErrorMessage = String.Format("{0}: {1}",
                                                  e.GetType().Name,
                                                  e.Message);
        }
        return response;
    }
