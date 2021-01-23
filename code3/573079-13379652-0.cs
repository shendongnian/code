    public class sqlconnect
    {
        public SqlConnection myConnection { get; set; }
        Settings1 set = new Settings1();
    	// Here you make a new one, use the existing instead from which this class is called.
    	// changed variable named from var to login..
        Login login = new Login(); 
    	
    	***EDITS***
    	// Constructor where you pass your login object
    	public sqlconnect(Login login)
    	{
    		this.login = login;
    	}
    
        public SqlConnection GetSqlConnection()
        {
            if (myConnection == null)
                myConnection = new SqlConnection("user id="+(login.user)+"; password="+(login.pass)+";server="+(set.SelectServer)+";Trusted_Connection="+(set.SelectContype)+";database="+(set.SelectDataBase)+"; connection timeout="+(set.Condrop)+"");
    
            return myConnection;
        }
    
    
    }
