    public event EventHandler SelectedNodeChanged
    {
       add { tree.SelectedNodeChanged += value; }
       remove { tree.SelectedNodeChanged-= value; }
    }
