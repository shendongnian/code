    public override async Task LoadAsync(bool includeDeleted = false)
    {
        Core.Logger.EnterMethod("_TasksData.Load");
        try
        {
            DataSet = Core.LogbookProData.Tasks.GetTasks(DataUserID, includeDeleted);
            LoadCompleted();
            dsTasks cacheData = await Cache.LoadAsync(ConvertTimeZone);
            if (cacheData != null)
                MergeDataSets(DataSet, cacheData);
            InitializeLayouts();
        }
        catch (Exception ex)
        {
            Core.Logger.LogException("_TasksData.Load", ex);
        }
        finally
        {
            Core.Logger.LeaveMethod("_TasksData.Load");
        }
    }
