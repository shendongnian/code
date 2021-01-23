    // Get your selected items:
    var items = ListBox1.Items.Where(i=>i.Selected).Select(i=>i.Value).ToArray(); 
    
    // Create a series of parameters @param0, @param1, @param2..N for each value.
    string paramNames = string.Join(", ", Enumerable.Range(0,items.Count()).Select(e=>"@param"+e)); 
    
    // Build the command text and insert the parameter names. 
    string commandText = "INSERT INTO Activity (Hostname,Site,Status,System_Dept,Business_Dept)" 
                    + "SELECT * FROM Inventory WHERE Site IN ("+ paramNames +")";
    
    command.CommandText = commandText; 
    
    // Now add your parameter values:  this binds @param0..N to the values selected. 
    
    for(int param=0;param<items.Count();param++)
    {
       command.Parameters.AddWithValue("@param" + param, items[param]); 
    }
