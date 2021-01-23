    comboBox.Items.Add("Access"); // make it equal to 31
    comboBox.Items.Add("Create"); // make it equal to 34
    comboBox.Items.Add("Delete"); // make it equal to 36
    comboBox.Items.Add("Modify"); // make it equal to 38
    
    Dictionary<int, int> mapTable = new Dictionary<int, int>();
    mapTable.Add(31, 0);
    mapTable.Add(34, 1);
    mapTable.Add(36, 2);
    mapTable.Add(38, 3);
