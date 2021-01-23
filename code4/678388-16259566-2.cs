    public static void RetrieveControlEventHandlers(Control c, string eventName)
    {
        Type type = c.GetType();
        FieldInfo eventKeyField = GetStaticNonPublicFieldInfo(type, "Event" + eventName);
        if (eventKeyField == null)
        {
            eventKeyField = GetStaticNonPublicFieldInfo(type, "EVENT_" + eventName.ToUpper());
            if (eventKeyField == null)
            {
                // Not all events in the WinForms controls use this pattern.
                // Other methods can be used to search for the event handlers if required.
                return null;
            }
        }
        object eventKey = eventKeyField.GetValue(c);
        PropertyInfo pi = type.GetProperty("Events",
           BindingFlags.NonPublic | BindingFlags.Instance);
        EventHandlerList list = (EventHandlerList)pi.GetValue(c, null);
        Delegate del = list[eventKey];
        if (del != null)
            list.RemoveHandler(eventKey, del);
    }
