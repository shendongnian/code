    using(var db = new MyEntityDatabase())
    {
        var widget      = from p in db.Widgets select p where p.ID == 1;
        var widget_diff = from p in db.Widgets_Changes select p where p.ID == 1;
        var properties = typeof(MyWidgetType).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach(var property in properties)
        {
             //widget.column = widget_diff.column ?? widget.colum;
             property.SetValue(property.GetValue(widget_diff) ?? property.GetValue(widget), widget);
        }
        //You can do the same for fields here if the entity has any fields (probably not).
    }
 
