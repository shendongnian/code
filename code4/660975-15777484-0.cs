    using System;
    using System.Data.Common;
    using System.Reflection;
    namespace Extensions
    {
        public delegate void RowUpdatedEventHandler(object sender, RowUpdatedEventArgs e);
        public delegate void RowUpdatingEventHandler(object sender, RowUpdatingEventArgs e);
        public static class DbDataAdapterExtension
        {
            public static void AddRowUpdatedHandler(this DbDataAdapter adapter, RowUpdatedEventHandler handler)
            {
                EventInfo updEvent = adapter.GetType().GetEvent("RowUpdated", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                if (updEvent != null)
                {
                    updEvent.AddEventHandler(adapter, Delegate.CreateDelegate(updEvent.EventHandlerType, handler.Method));
                }
            }
            public static void AddRowUpdatingHandler(this DbDataAdapter adapter, RowUpdatingEventHandler handler)
            {
                EventInfo updEvent = adapter.GetType().GetEvent("RowUpdating", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                if (updEvent != null)
                {
                    updEvent.AddEventHandler(adapter, Delegate.CreateDelegate(updEvent.EventHandlerType, handler.Method));
                }
            }
        }
    }
