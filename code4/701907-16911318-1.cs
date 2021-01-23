    private void RemoveClickEvent(Button b)
    {
        FieldInfo f1 = typeof(Control).GetField("EventClick", 
        BindingFlags.Static | BindingFlags.NonPublic);
        object obj = f1.GetValue(b);
        PropertyInfo pi = b.GetType().GetProperty("Events",  
        BindingFlags.NonPublic | BindingFlags.Instance);
        EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
        list.RemoveHandler(obj, list[obj]);
    }
