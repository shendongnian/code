    for (int i = 0; i< materias[0].ChildNodes.count; i++)
    {
        AddRow(i, materias[0].ChildNodes)
        i += 3;
    }
    
    private void AddRow(int startIndex, XmlNodeList Nodes)
    {
        int NodesOnThisRow = 3;
        if (Nodes.Count - startIndex < 3)
            NodesOnThisRow = Nodes.Count - startIndex;
        Panel newPanel = new Panel();
        int x = 8;
        for (int i= 0; i< NodesOnThisRow; i++)
        {
           Label L = new Label();
           TextBox T = new TextBox();
           //You could dock these left so they just appear one after the other, or since there
           //is only 3 you could just hard code the 3 x values, or calc them
           L.Left = x;
           T.Left = x + 120;
           x += 250
           newPanel.Controls.Add(L);
           newPanel.Controls.Add(T);
        }
        notas_panel.Controls.Add(newPanel);
        newPanel.BringToFront();
    }
