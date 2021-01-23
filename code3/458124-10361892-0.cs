	public class Sqlite_DB
	{	
		private SqliteConnection CON;
		public 	SqliteCommand COM;
		
		
	
		string dbName = System.IO.Path.Combine(@"sdcard", @"testDB.db3");
		
		public Sqlite_DB()
		{
			TOUPPER.RegisterFunction(typeof(TOUPPER));
			CON=new SqliteConnection(String.Format("Data Source={0};Pooling={1}", dbName, false));
			COM=new SqliteCommand(CON);
			
		}
		public void close()
		{
			COM.Clone();
			CON.Clone();
		}
		public void open()
		{
			CON.Open();
		}
		
	}
	
	#region TOUPPER
	[Mono.Data.Sqlite.SqliteFunction(Name = "TOUPPER", Arguments = 1, FuncType = FunctionType.Scalar)]
    public class TOUPPER: Mono.Data.Sqlite.SqliteFunction
    {
	    public override object Invoke(object[] args)
        {
		    return args[0].ToString().ToUpper();
       	}
    }		
    	
	[Mono.Data.Sqlite.SqliteFunction(Name = "COLLATION_CASE_INSENSITIVE", FuncType = FunctionType.Collation)]
	class CollationCaseInsensitive : Mono.Data.Sqlite.SqliteFunction
	{
		public override int Compare(string param1, string param2) 
		{
			return String.Compare(param1, param2, true);
		}
	} 
	#endregion
	
	
	
	
	
	
	public class TEST_X
	{
		string strValue="ir";//test
		public void MUSTERI()
		{
			string srg="select * from "+Cari_._
					+"where TOUPPER(musteri) like '%"+strValue.toUpper()+"%';";
			try {
				Sqlite_DB d=new Sqlite_DB();
				d.open();
				
				d.COM.CommandText=srg;
				
				SqliteDataReader dr=d.COM.ExecuteReader();
			
				while (dr.Read()) 
				{
					
					Android.Util.Log.Error(">>>>",dr[0].ToString()+"<<<");
					
				}
				d.close();
				
			} catch (Exception ex) {
				Android.Util.Log.Error(">>>>",ex+"<<<");
			}
			
		}
	}
    ID   musteri    
    ---  ---------- 
    1    İrem                   
    2    Kadir                   
    3    Demir
    
    returning result:
    
    -İrem
    
    -Kadir
    
    -Demir
	
