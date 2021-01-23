    	string test = "01-12-12";
        try{
             DateTime dateTime = DateTime.Parse(test);
             test = dateTime.ToString("dd/yyyy");
        }
        catch (FormatException exc)
        {
            MessageBox.Show(exc.Message);
        }
		
	    
