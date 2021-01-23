    try
    {
        foreach(string line in File.ReadAllLines(PathFile))
        {
           comboBox1.Items.Add(line);           
        }
    
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error : " + ex.Message);
    }
