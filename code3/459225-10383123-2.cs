    string path = txtFilePath.Text;               
    using(StreamWriter sw = File.AppendText(path))
    {
      foreach (var line in employeeList.Items)                 
      {                    
        Employee e = (Employee)line; // unbox once
        sw.WriteLine(e.FirstName);                     
        sw.WriteLine(e.LastName);                     
        sw.WriteLine(e.JobTitle); 
      }                
    }     
