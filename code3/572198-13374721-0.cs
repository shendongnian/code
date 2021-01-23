        private void ReflectMethods(Control control, Control baseControl, string[] excludedEventNames = null, string[] includedEventNames = null)
        {
            Type baseType = baseControl.GetType();
            Type ownType = control.GetType();
            EventHandlerList events = typeof(Control).GetProperty("Events", BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic).GetValue(baseControl, null) as EventHandlerList;
            foreach (EventInfo baseEventInfo in baseType.GetEvents())
            {
                if (excludedEventNames != null && excludedEventNames.Contains(baseEventInfo.Name))
                    continue;
                if (includedEventNames != null && !includedEventNames.Contains(baseEventInfo.Name))
                    continue;
                //
                // Checking if current control has the same event..
                //
                foreach (EventInfo ownEventInfo in ownType.GetEvents())
                {
                    if (ownEventInfo.Name == baseEventInfo.Name)
                    {
                        object eventField = typeof(Control).GetField("Event" + baseEventInfo.Name, BindingFlags.NonPublic | BindingFlags.Static).GetValue(baseControl);
                        Delegate aDel = events[eventField];
                        ownEventInfo.AddEventHandler(control, aDel);
                    }
                }
            }
        }
