        // define USB class guid (from devguid.h)
        static readonly Guid GUID_DEVCLASS_USB = new Guid("{36fc9e60-c465-11cf-8056-444553540000}");
        static void watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject instance = (ManagementBaseObject )e.NewEvent["TargetInstance"];
            if (new Guid((string)instance["ClassGuid"]) == GUID_DEVCLASS_USB)
            {
                // we're only interested by USB devices, dump all props
                foreach (var property in instance.Properties)
                {
                    Console.WriteLine(property.Name + " = " + property.Value);
                }
            }
        }
