    grid.Sort.Enabled = false;
    grid.Data Source = _data source_;
    //Add a single object to the beginning of the grid
    grid.Nodes.Insert(0, _new_object_);
    //Add a single object to the beginning of the binding list
    I Binding List bl = ...;
    bl.Insert(0, _new_object_); 
