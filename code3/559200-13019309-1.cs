    public class MemberColumn
    {
        private MemberColumn(DbType columnType) { ColumnType = columnType; }
        public DbType ColumnType { get; private set; }
        private readonly static MemberColumn _address1 = new MemberColumn(DbType.String);
        public static Address1 { get { return _address1; } }
        private readonly static MemberColumn _city = new MemberColumn(DbType.String);
        public static City { get { return _city; } }
        private readonly static MemberColumn _state = new MemberColumn(DbType.String);
        public static State { get { return _state; } }
    }
