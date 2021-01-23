    public static List<MyClass> Assign (MyClass target, List<MyClass> assign, int i)
    {
        i++;
        target.ID = assign[i].ID;
        target.MyVar = assign[i].MyVar;
    }
