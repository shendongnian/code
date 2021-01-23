    public static string WriteVisualTree(DependencyObject parent)
    {
        if (parent == null)
            return "No Visual Tree Available. DependencyObject is null.";
    
        using (var stringWriter = new StringWriter())
        using (var indentedTextWriter = new IndentedTextWriter(stringWriter, "  "))
        {               
            WriteVisualTreeRecursive(indentedTextWriter, parent, 0);
            return stringWriter.ToString();
        }
    }
    
    private static void WriteVisualTreeRecursive(IndentedTextWriter writer, DependencyObject parent, int indentLevel)
    {
        if (parent == null)
            return;
        
        int childCount = VisualTreeHelper.GetChildrenCount(parent);
        string typeName = parent.GetType().Name;
        string objName = parent.GetValue(FrameworkElement.NameProperty) as string;
        
        writer.Indent = indentLevel;
        writer.WriteLine(String.Format("[{0:000}] {1} ({2}) {3}", indentLevel, 
                                                                  String.IsNullOrEmpty(objName) ? typeName : objName, 
                                                                  typeName, childCount)
                        );
    
        for (int childIndex = 0; childIndex < childCount; ++childIndex)
            WriteVisualTreeRecursive(writer, VisualTreeHelper.GetChild(parent, childIndex), indentLevel + 1);
    }
    
    public static string WriteLogicalTree(DependencyObject parent)
    {
        if (parent == null)
            return "No Logical Tree Available. DependencyObject is null.";
    
        using (var stringWriter = new StringWriter())
        using (var indentedTextWriter = new IndentedTextWriter(stringWriter, "  "))
        {
            WriteLogicalTreeRecursive(indentedTextWriter, parent, 0);
            return stringWriter.ToString();
        }
    }
    
    private static void WriteLogicalTreeRecursive(IndentedTextWriter writer, DependencyObject parent, int indentLevel)
    {
        if (parent == null)
            return;
    
        var children = LogicalTreeHelper.GetChildren(parent).OfType<DependencyObject>();
        int childCount = children.Count();
    
        string typeName = parent.GetType().Name;
        string objName = parent.GetValue(FrameworkElement.NameProperty) as string;
        
        double actualWidth = (parent.GetValue(FrameworkElement.ActualWidthProperty) as double?).GetValueOrDefault();
        double actualHeight = (parent.GetValue(FrameworkElement.ActualHeightProperty) as double?).GetValueOrDefault();
    
        writer.Indent = indentLevel;
        writer.WriteLine(String.Format("[{0:000}] {1} ({2}) {3}", indentLevel,
                                                                  String.IsNullOrEmpty(objName) ? typeName : objName,
                                                                  typeName, 
                                                                  childCount)
                        );
    
        foreach (object child in LogicalTreeHelper.GetChildren(parent))
        {
            if (child is DependencyObject)
                WriteLogicalTreeRecursive(writer, (DependencyObject)child, indentLevel + 1);
        }
    
    }
