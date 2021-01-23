    public static List<DependencyObject> ListLogical( DependencyObject parent)
    {
        var depList = new List<DependencyObject>
        {
            parent
        };
        foreach ( var child in LogicalTreeHelper.GetChildren( parent ).OfType<DependencyObject>() )
        {
            depList.AddRange( ListLogical( child ) );
        }
        return depList;
    }
