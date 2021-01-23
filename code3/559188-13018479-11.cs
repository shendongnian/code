    public enum MemberColumn
    {
        [DbType(DbType.String)] Address1,
        [DbType(DbType.String)] Address2,
        [DbType(DbType.String)] FirstName,
        [DbType(DbType.String)] LastName,
        [DbType(DbType.DateTime)] DateOfBirth,
    }
    // ... later, in some method somewhere:
    
    MemberColumn c = MemberColumn.Address1;
    
    DbType dbType = DbHelper<MemberColumn>.GetColumnType(c); // sets dbType to DbType.String
