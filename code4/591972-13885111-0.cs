        private void Button_Click(object sender, RoutedEventArgs e)
    {
        object obj = new MyType();
        List<object> list = new List<object>();
        list.Add(obj);
        foreach (object o in obj in list){
        obj.GetType().InvokeMember(
            "MyOtherTypes",
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty,
            Type.DefaultBinder,
            obj,
            ob);
        UpdateJson(obj);
        }
    }
