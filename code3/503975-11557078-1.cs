        Foo item = combo2data.Where(f => f.name.Equals("Tom")).FirstOrDefault();
        if (item != null)
        {
            combo2data.Remove(item);
            comboBox2.DataSource = null;
            comboBox2.DataSource = combo2data;  
            comboBox2.ValueMember = "path";  
            comboBox2.DisplayMember = "name";  
        }
