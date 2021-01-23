        System.Reflection.FieldInfo[] fi = 
        this.GetType().GetFields(BindingFlags.Public | 
        BindingFlags.Instance | BindingFlags.NonPublic);
    
    for (int i = 0; i < fi.Length; ++i)
    {
        FieldInfo info = fi[i];
        
        //info can be Button, Menuitem, ToolbarButton.....
        //info.Name returns true name of control
        //        - menuItem1, btnChangelanguage....
        if (typeof(MenuItem) == info.FieldType)
        {
            MenuItem item = (MenuItem)info.GetValue(this);
            item.Text = resources.GetString(info.Name + ".Text");
        }
    }
