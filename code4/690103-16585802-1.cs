        try
        {
            int resultID;
            if(Int32.TryParse(e.CommandArgument.ToString().Trim(), out resultID))
            {
                 ViewState["id"] = e.CommandArgument.ToString().Trim();
                 .....
            }
            else
                // handle the case of not an integer value
