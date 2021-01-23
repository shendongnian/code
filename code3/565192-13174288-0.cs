    this.Details.Dispatcher.BeginInvoke(() =>
    {
    Container newRecord = this.DataWorkspace.ApplicationData.Containers.AddNew();
    newRecord.SubContainer = this.DataWorkspace.ApplicationData.SubContainers.AddNew();
    });
