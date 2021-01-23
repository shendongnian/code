    System.Windows.Forms.MenuItem menuItem = new System.Windows.Forms.MenuItem();
    System.Reflection.FieldInfo fieldInfoData = menuItemType.GetField("data",
        System.Reflection.BindingFlags.NonPublic |
        System.Reflection.BindingFlags.Instance |
        System.Reflection.BindingFlags.GetField);
    
    object dataField = fieldInfoData.GetValue(menuItem);
    object onDrawItem = fieldInfoOnDrawItem.GetValue(dataField);
