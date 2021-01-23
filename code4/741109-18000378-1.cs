    string[] lines = File.ReadAllLines(@"e:\temp\query.sql");
    using (var mmf = MemoryMappedFile.CreateFromFile(@"e:\temp\query2.sql", FileMode.Create, "txt", new FileInfo(@"e:\temp\query.sql")Length))
    {       
        StringBuilder sb = new StringBuilder();
        using (MemoryMappedViewStream mmvs = mmf.CreateViewStream())
        {
           StreamWriter writer = new StreamWriter(mmvs);
           for (int i = 0; i < lines.Length; i++)
           {
              var bits = lines[i].Split('\'');
              var value1 = bits[1];
              var value2 = bits[3];
              var value3 = bits[5];
              sb.AppendFormat("INSERT [PreStaging].[Import_AccountEmployeeMapping]
                              ([AccountName], [EmployeeID], [PlatformID])
                             VALUES (N'{0}', {1}, {2})", value1, value2, value3);
              
              writer.WriteLine(message.ToString()); 
          }
       }
    }
