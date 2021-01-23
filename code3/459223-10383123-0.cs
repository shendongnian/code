    string path = txtFilePath.Text;               
    using(StreamWriter sw = File.AppendText(path))
    {
      foreach (var line in employeeList.Items)                 
      {                     
        sw.WriteLine(((Employee)line).FirstName);                     
        sw.WriteLine(((Employee)line).LastName);                     
        sw.WriteLine(((Employee)line).JobTitle); 
      }                
    }     
