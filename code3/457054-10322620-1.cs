    string path = txtFilePath.Text;
    // This text is added only once to the file.
    if (!File.Exists(path)) 
    {
        using (StreamWriter sw = File.CreateText(path)) 
        {
            foreach (string line in employeeList.Items)
                sw.WriteLine(line);
        }	
    } 
    else 
    {
        using (StreamWriter sw = File.AppendText(path)) 
        {
            foreach (string line in employeeList.Items)
                sw.WriteLine(line);
        }
    }
