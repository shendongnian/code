    var c = ((Control) e.CommandSource).NamingContainer;
    while (c.GetType() != typeof(GridViewRow))
    {
        c = c.Parent;
    }
    var currentRow = (GridViewRow) c;
