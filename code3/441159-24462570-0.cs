    // filter call logs by type = missed
    string queryFilter = String.Format ("{0}={1}", CallLog.Calls.Type, (int)CallType.Missed);
    // filter in desc order limit by 3
    string querySorter = String.Format ("{0} desc limit 3", CallLog.Calls.Date);
    // CallLog.Calls.ContentUri is the path where data is saved
    Android.Database.ICursor queryData = ContentResolver.Query (CallLog.Calls.ContentUri, null, queryFilter, null, querySorter);
    while(queryData.MoveToNext())
    {
       String dialNumber = queryData.GetString     (queryData.GetColumnIndex(CallLog.Calls.Number));
      // do your stuffs, get more data, whatever...
    }
