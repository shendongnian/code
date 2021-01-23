    public sealed class AppDb
    {
        public sealed class SqlTableMeta
        {    
          //id -for usage by jquery, name for the DataTable returnd in the next block of code
            public static DbTbl Time = new DbTbl(HTDB_Tables.TblTime, HTtIDs.tblTime);
        }
        public sealed class SqlSProcMeta
        {
            public static SProc Time = new SProc(HTSPs.SP_GetTimesWithCustomerNames,
                                                 HTtIDs.SProcTime,
                                                 HTSPs.GetTimesWithCustomerNames.SqlParLst("3571", "9", "2012", "1"));
        }
    }
