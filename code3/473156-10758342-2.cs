    cmd.CommandText = "INSERT TechOpsProjectTracker (ID, [Project Name]) VALUES (@ID, @ProjectName)";    
    Dictionary<int, string> dt = new Dictionary();
        for (int i=0; i<ListId.Count; i++)
        {
        dt.Add(ListID[i], ListTitle[i]);
        }
        
        foreach (KeyValuePair<int, string> pair in dt)
        {
           SqlParameter a = cmd.Parameters.Add("@ID", SqlDbType.Int);
     
           // or write what is the type of your column in your table after SqlDbType. 
           
           a.Value = pair.key;
    
           SqlParameter b = cmd.Parameters.Add("@Project", SqlDbType.Varchar, 50);
           
            // 50 is what you gave max length to your db column//
    
            b.Value = pair.value;
        
            int v = cmd.ExecuteNonQuery();
    
            if ( v == 1 )
            {
               MessageBox.Show("Successfully Done !");
            }
    
            else
            {
               MessageBox.Show("Oops ! I can' t insert Successfully")
            }
        }
