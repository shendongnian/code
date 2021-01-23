    private void Button_Click(object sender, RoutedEventArgs e)
    {
        object obj = new MyType();
        List<list<object>> list = new List<List<object>>();
        object ob = (object) list;
        obj.GetType().InvokeMember(
            "MyOtherTypes",
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty,
            Type.DefaultBinder,
            obj,
            ob);
        UpdateJson(obj);
    }
