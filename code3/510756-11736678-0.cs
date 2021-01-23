    [TestClass]
    public class GenericDatabaseStorageTests
    {
        [TestMethod]
        public void CurrencyOracleExtractToFile( )
        {
            GenericDatabaseStorage<OracleConnection, OracleCommand> storage =
                new GenericDatabaseStorage<OracleConnection, OracleCommand>( 
                    typeof(TestRecord), 
                    "User Id=SHELL;Password=shell;Data Source=ora9dev"
                );
            storage.SelectSql = "SELECT * FROM CURRENCY";
            storage.FillRecordCallback = new FillRecordHandler( FillRecordOrder );
            FileDataLink.EasyExtractToFile( storage, "tempord.txt" );
            FileDataLink link = new FileDataLink( storage );
            link.ExtractToFile( "tempord.txt" );
            TestRecord[] res = (TestRecord[])CommonEngine.ReadFile(typeof(TestRecord), "tempord.txt");
            if ( File.Exists( "tempord.txt" ) )
                File.Delete( "tempord.txt" );
            Assert.AreEqual( 3, res.Length );
            Assert.AreEqual( "AED", res[ 0 ].CurrencyCode );
            Assert.AreEqual( "AFA", res[ 1 ].CurrencyCode );
            Assert.AreEqual( "ALL", res[ 2 ].CurrencyCode );
        }
        
        public void FillRecordOrder( object rec, object[ ] fields )
        {
            TestRecord record = ( TestRecord )rec;
            record.CurrencyCode = ( string )fields[ 0 ];
            record.Name = ( string )fields[ 1 ];
        }
    }
