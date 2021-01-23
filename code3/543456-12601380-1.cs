        DataTable table = new DataTable("Kunde"); 
        table.Columns.Add("KundeID", typeof(Int32)); 
        table.Columns.Add("KundeName", typeof(String)); 
        table.Columns.Add("Produkt", typeof(String));
        table.Columns.Add("Comment", typeof(String));
       
        object[] o1 = { 1, "Michael", "Jogurt", "nichts" }; 
        object[] o2 = { 2, "Raj","","Ich bin cool" };
        object[] o3 = { 3, "Gary", "Fanta","yahoo" }; 
        object[] o4 = { 4, "Miky", "Sprite","" };
       
        table.Rows.Add(o1); 
        table.Rows.Add(o2); 
        table.Rows.Add(o3); 
        table.Rows.Add(o4); 
        Dictionary<int,string> dictObj=new Dictionary<int, string>();
        for (int i = 0; i < table.Rows.Count; i++)
        {
            dictObj.Add(Convert.ToInt32(table.Rows[i][0].ToString()), table.Rows[i][2].ToString());
        }
        foreach (var obj in dictObj)
        {
            if (string.IsNullOrEmpty(obj.Value))
            {
                table.Columns.Add(obj.Value, typeof(String));
                DataRow row = table.Rows[obj.Key];
                row[obj.Value] = "X";
            }
        }
