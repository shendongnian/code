    List<List<Panel>> panelGrid = new List<List<Panel>>();
    for (var i = 0; i < 5; i++)
    {  
        var panelRow = new List<Panel>();
        for (var j = 0; j < 5; j++)
        {
            panelRow.Add(new Panel());
            // add positioning logic here
        }
        panelGrid.Add(panelRow);
    }
