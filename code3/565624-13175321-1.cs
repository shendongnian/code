    var files = (string[])e.Data.GetData(DataFormats.FileDrop);
    
    foreach(var file in files)
    {
        if(System.IO.Path.GetExtension(file).Equals(".txt", InvariantCultureIgnoreCase)
        {
            //file has correct extension, do something with file
        }
        else
        {
            MessageBox.Show("Not a text file");
        }
    }
