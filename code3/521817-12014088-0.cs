    using System;
    using System.Text;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    
    public class Hello1
    {
       public static void Main()
       {
    	try
    	{
    		using (SqlConnection conn = new SqlConnection("server=.;integrated security=true"))
    		{
    			conn.Open ();
    
    			// The .cs file must be saved as Unicode, obviously...
    			//
    			string s = "Работа в германии"; 
    
    			byte[] b = Encoding.GetEncoding(1251).GetBytes (s);
    			
    			// Create a test table
    			//
    			SqlCommand cmd = new SqlCommand (
    				@"create table #t (
    					c1 varchar(100) collate Latin1_General_CI_AS, 
    					c2 varchar(100) collate Cyrillic_General_CI_AS)", 
    				conn);
    			cmd.ExecuteNonQuery ();
    
    			// Insert the same value twice, the original Unicode string
    			// encoded as CP1251
    			//
    			cmd = new SqlCommand (
    				@"insert into #t (c1, c2) values (@b, @b)", conn);
    			cmd.Parameters.AddWithValue("@b", b);
    			cmd.ExecuteNonQuery ();
    
    			// Read the value as Latin collation 
    			//
    			cmd = new SqlCommand (
    				@"select c1 from #t", conn);
    			string def = (string) cmd.ExecuteScalar ();
    
    			// Read the same value as Cyrillic collation
    			//
    			cmd = new SqlCommand (
    				@"select c2 from #t", conn);
    			string cyr = (string) cmd.ExecuteScalar ();
    
    			// Cannot use Console.Write since the console is not Unicode
    			//
    			MessageBox.Show(String.Format(
    				@"Original: {0}  Default collation: {1} Cyrillic collation: {2}", 
    					s, def, cyr));
    		}
    
    	}
    	catch(Exception e)
    	{
    		Console.WriteLine (e);
    	}	
       }
    }
