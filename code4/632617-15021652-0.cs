    var shelvesetOld = vcs.QueryShelvesets("shelveset_old", null).FirstOrDefault();
    var shelvesetOldChanges = vcs.QueryShelvedChanges(shelvesetOld)[0].PendingChanges;
    var shelvesetNew = vcs.QueryShelvesets("shelveset_new", null).FirstOrDefault();
    var shelvesetNewChanges = vcs.QueryShelvedChanges(shelvesetNew)[0].PendingChanges;
    var differences = new List<PendingChange>();
    foreach (var oldChange in shelvesetOldChanges) {
        var shelvesetNewChange = shelvesetNewChanges.FirstOrDefault(shelvesetChangeSearch => shelvesetChangeSearch.ServerItem.Equals(oldChange.ServerItem));
        if (shelvesetNewChange == null) {
            differences.Add(oldChange);
            continue;
        }
        if (!shelvesetNewChange.UploadHashValue.SequenceEqual(oldChange.UploadHashValue)) {
            differences.Add(oldChange);
        }
    }
