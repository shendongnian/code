    public static DependencyProperty ListOfNamesProperty =
        DependencyProperty.Register("ListOfNames", typeof(string[]), typeof(ProjectList),
        new PropertyMetadata(ListOfNamesChaned));
    private static void ListOfNamesChaned(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        List<ProjectItemList> auxList = new List<ProjectItemList>();
        foreach (string s in value)
        {
            ProjectItemList il = new ProjectItemList();
            il.Nombre = s;
            this.lb_projects.Items.Add(il);
        }
    }
    public string[] ListOfNames
    {
        get
        {
            return (string[])GetValue(ListOfNamesProperty);
        }
        set
        {
            SetValue(ListOfNamesProperty, value);
        }
    }
