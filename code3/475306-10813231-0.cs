    var list = new List<DataGridView>();
    for (int i = 1; i <nCounter ; i++)
    {
        System.Windows.Forms.DataGridView dvName = new DataGridView();
        dvName.Name = "dv" + i.ToString();
        list.Add(dvName);
        // other operations will go here..
    }
    foreach (var dv in list)
    {    
        ...do something... 
    }
    DataGridView secondDv = list.Single(dv=>dv.Name == "dv2");
    secondDv.DoSomething()
