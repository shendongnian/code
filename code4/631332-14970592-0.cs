    try
    {
    	// do something
    }
    catch(SQLException sqlex)
    {
    	string exception = sqlex.ToString();
    	System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Home\Desktop\sqlException.txt");
    	file.WriteLine(exception);
    	file.Close();
    }
    catch(Exception e)
    {
    	string exception = e.ToString();
    	System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Home\Desktop\generalException.txt");
    	file.WriteLine(exception);
    	file.Close();
    }
