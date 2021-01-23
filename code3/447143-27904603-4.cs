    _treeViewAdv.Model = _model;
    _treeViewAdv.BeginUpdate();
    for (int i = 0; i < 20; i++)
    {
        Node parentNode = new ColumnNode("root" + i, "",0);
        _model.Nodes.Add(parentNode);
        for (int n = 0; n < 2; n++)
        {
            Node childNode = new ColumnNode("child" + n,"Further Information",1);
            parentNode.Nodes.Add(childNode); 
        }
    }
    _treeViewAdv.EndUpdate();
