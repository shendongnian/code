    public void Save_Click(object sender, EventArgs e)
    {
        StreamWriter file = 
          new StreamWriter(txtFilePath.Text, true);//Open and append
        foreach (string line in employeeList.Items) {
           file.WriteLine(line);
        }
        file.Close();
    }
