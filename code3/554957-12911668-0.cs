    var updateSession = new UpdateSession();
    var updateSearcher = updateSession.CreateUpdateSearcher();
    updateSearcher.Online = false; //set to true if you want to search online
    try
    {
        var searchResult = updateSearcher.Search("IsInstalled=0 And IsHidden=0");
        if (searchResult.Updates.Count > 0)
        {
            MessageBox.Show("There are updates available for installation");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message,"Error");
    }
