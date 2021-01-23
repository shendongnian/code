    try
    	{
    	    // Read in non-existent file.
    	    using (StreamReader reader = new StreamReader("TextFile1.txt"))
    	    {
    		reader.ReadToEnd();
    	    }
    	}
    catch (FileNotFoundException ex)
    	{
            MessageBox.Show("The file don't exist!", "Problems!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    	    // Write error.
    	    Console.WriteLine(ex);
    	}
