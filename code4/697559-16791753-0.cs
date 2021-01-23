	var status = _workspace.Merge(sourceTfsPath, targetTfsPath, null, null, LockLevel.None, RecursionType.Full,
		MergeOptions.AlwaysAcceptMine);
	Trace.WriteLine(status.NumOperations);
	var conflicts = _workspace.QueryConflicts(null, true);
	foreach (var conflict in conflicts)
	{
		conflict.Resolution = Resolution.AcceptYours;
		_workspace.ResolveConflict(conflict);
	}
