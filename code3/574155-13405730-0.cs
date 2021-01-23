    private void button2_Click(object sender, EventArgs e)
    {
    	string fileName = @"C:\Hello1";
    	if
    
    		(File.Exists(fileName))
    	{
    		File.Delete(fileName);
    		MessageBox.Show("File is deleted");
    	}
    	else
    	{
    		FileInfo createFile = new FileInfo(fileName);
    		using(FileStream create = createFile.Create())
    		{
    			MessageBox.Show("Created");
    		}
    	}
    }
