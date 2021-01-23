    Array a = Array.CreateInstance(typeof(SqlParameter), 4);
    a.SetValue(new SqlParameter("@mBatchName", mCollectionID), 0);
    a.SetValue(new SqlParameter("@mTATCash", mTATCash), 1);
    a.SetValue(new SqlParameter("@mTATradingOrdinary", mTATradingOrdinary), 2);
    a.SetValue(new SqlParameter("@mTATradingType", mTATradingType), 3);
    cmd.Parameters.AddRange(a);
