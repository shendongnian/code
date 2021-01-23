    while (reader.Read())
    {
       // not sure  why you started at 3, 
       // this code is generic so it will also work for tables with less that 3 columns
       // but maybe that is something you can omit
       for (int i = 0; i < reader.FieldCount ; i++)
       {
          if (reader[i] == null)
             continue;
          
          listBox2.Items.Add(reader[i].ToString());      
       }
    }
