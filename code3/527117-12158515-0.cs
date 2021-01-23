    BindingFlags AllBindings = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
                
    List<FieldInfo> lst = new List<FieldInfo>();
    
    foreach (EventInfo ei in btn.GetType().GetEvents(AllBindings))
    {
        Type dt = ei.DeclaringType;
        FieldInfo fi = dt.GetField(ei.Name, AllBindings);
        if (fi != null)
            lst.Add(fi);
    }
    
    foreach (FieldInfo fi in lst)
    {
        EventInfo ei = btn.GetType().GetEvent(fi.Name, AllBindings);
        if (ei != null)
        {
            object val = fi.GetValue(btn);
            Delegate mdel = (val as Delegate);
            if (mdel != null)
            {
                foreach (Delegate del in mdel.GetInvocationList())
                    ei.RemoveEventHandler(btn, del);
            }
        }
    }
