        combo2data.RemoveAt(0); //Removing by Index from the dataSource which is a List
        
        //Rebind
        comboBox2.DataSource = null;
        comboBox2.DataSource = combo2data;  
        comboBox2.ValueMember = "path";  
        comboBox2.DisplayMember = "name";  
