    private void Form1_Load(object sender, EventArgs e)
    {
        TreeModel _model = new TreeModel();
        treeViewAdv1.Model = _model;
        treeViewAdv1.BeginUpdate();
        for (int i = 0; i < 20; i++)
        {
            Node parentNode = new Node("root" + i);
            _model.Nodes.Add(parentNode);
            for (int n = 0; n < 2; n++)
            {
                Node childNode = new Node("child" + n);
                parentNode.Nodes.Add(childNode);
            }
        }
        NodeTextBox ntb = new NodeTextBox();
        ntb.DataPropertyName = "Text";       
        this.treeViewAdv1.NodeControls.Add(ntb);
        treeViewAdv1.EndUpdate();
        
        
    }
