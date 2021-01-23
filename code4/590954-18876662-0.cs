    con = new iDB2Connection(connectString);
    
    try 
    { 
    	con.Open(); 
    }
    catch (iDB2ConnectionTimeoutException ex)
    { 
    	Console.WriteLine(ex.Message); 
    }
    catch (iDB2DCFunctionErrorException ex)
    { 
    	Console.WriteLine(ex.Message); 
    }
    catch (AccessViolationException ex)
    { 
    	Console.WriteLine(ex.Message);
    } 
    finally
    {
    	if (con != null && con.State == ConnectionState.Open)
    	        con.Close();
    }
