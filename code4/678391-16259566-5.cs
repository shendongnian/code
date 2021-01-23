    // Also searches up the inheritance hierarchy
    private static FieldInfo GetStaticNonPublicFieldInfo(Type type, string name)
    {
        FieldInfo fi;
        do
        {
            fi = type.GetField(name, BindingFlags.Static | BindingFlags.NonPublic);
            type = type.BaseType;
        } while (fi == null && type != null);
        return fi;
    }
    private static object GetControlEventKey(Control c, string eventName)
    {
        Type type = c.GetType();
        FieldInfo eventKeyField = GetStaticNonPublicFieldInfo(type, "Event" + eventName);
        if (eventKeyField == null)
        {
            if (eventName.EndsWith("Changed"))
                eventKeyField = GetStaticNonPublicFieldInfo(type, "Event" + eventName.Remove(eventName.Length - 7)); // remove "Changed"
            else
                eventKeyField = GetStaticNonPublicFieldInfo(type, "EVENT_" + eventName.ToUpper());
            if (eventKeyField == null)
            {
                // Not all events in the WinForms controls use this pattern.
                // Other methods can be used to search for the event handlers if required.
                return null;
            }
        }
        return eventKeyField.GetValue(c);
    }
    private static EventHandlerList GetControlEventHandlerList(Control c)
    {
        Type type = c.GetType();
        PropertyInfo pi = type.GetProperty("Events",
           BindingFlags.NonPublic | BindingFlags.Instance);
        return (EventHandlerList)pi.GetValue(c, null);
    }
