    System.Type menuItemType = typeof(System.Windows.Forms.MenuItem);
    
    System.Type menuItemDataType = menuItemType.GetNestedType("MenuItemData",
        System.Reflection.BindingFlags.NonPublic);
    
    System.Reflection.FieldInfo fieldInfoOnDrawItem= menuItemDataType.GetField("onDrawItem", 
        System.Reflection.BindingFlags.NonPublic | 
        System.Reflection.BindingFlags.Instance |
        System.Reflection.BindingFlags.GetField ); 
