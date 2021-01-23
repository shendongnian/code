    using (var scope = new TransactionScopeMS())
    {
        foreach (var change in changes)
        {
            switch (change.ChangeType)
            {
                 case ChangeTypeEnum.Insert:
                      var result = DataAccess.InsertTableRow(sourceEnvironmentId, SuperClientVendorID,
                                                                   DatabaseName, DataRouteName, change,
                                                                   typeNamespace);
                      postList.Add(result);
                      break;
                 case ChangeTypeEnum.Update:
                      DataAccess.UpdateTableRow(sourceEnvironmentId, SuperClientVendorID, DatabaseName,
                                                      DataRouteName, change, typeNamespace);
                      postList.Add(change);
                      break;
            }
        }
        scope.Complete();
    }
