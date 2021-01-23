    /// <summary>
    /// Special method to handle the Drop down list value changing 
    /// but ASP not accurately modifying the controls
    /// </summary>
    private void HandlePossibleBottomRowEvents()
    {
        var page = associatedGridView.Page;
        var request = page.Request;
        var possibleCall = request.Form["__EventTarget"];
        if (possibleCall != null)
        {
            if (possibleCall.Contains("pagerDDL"))
            {
                var newPageSize = request[possibleCall];
                var newSize = int.Parse(newPageSize);
                if (associatedGridView.PageSize != newSize)
                    UpdatePageSize(newSize);
            }
        }
    }
