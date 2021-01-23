    	string x = "01-12-12";
        try{
             DateTime test = DateTime.Parse(x);
             x = test.ToString("dd-yyyy");
        }
        catch (FormatException exc)
        {
            MessageBox.Show(exc.Message);
        }
		
	    
