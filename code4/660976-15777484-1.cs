    using System;
    using System.Data.Common;
    using System.Reflection;
    namespace Extensions
    {
        /// <summary>
        /// Delegate event handler used with the <c>DbDataAdapter.RowUpdated</c> event.
        /// </summary>
        public delegate void RowUpdatedEventHandler(object sender, RowUpdatedEventArgs e);
        /// <summary>
        /// Delegate event handler used with the <c>DbDataAdapter.RowUpdating</c> event.
        /// </summary>
        public delegate void RowUpdatingEventHandler(object sender, RowUpdatingEventArgs e);
        public static class DbDataAdapterExtension
        {
            private static EventInfo GetEvent(string eventName, Type type)
            {
                return type.GetEvent(eventName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            }
            /// <summary>
            /// Registers a <c>RowUpdatedEventHandler</c> with this instance's <c>RowUpdated</c> event.
            /// </summary>
            /// <param name="handler">The event handler to register for the event.</param>
            /// <returns><c>true</c> if the event handler was successfully registered, otherwise <c>false</c>.</returns>
            public static bool AddRowUpdatedHandler(this DbDataAdapter adapter, RowUpdatedEventHandler handler)
            {
                EventInfo updEvent = GetEvent("RowUpdated", adapter.GetType());
                if (updEvent != null)
                {
                    try
                    {
                        if (handler.Method.IsStatic)
                        {
                            updEvent.AddEventHandler(adapter, Delegate.CreateDelegate(updEvent.EventHandlerType, handler.Method));
                        }
                        else
                        {
                            updEvent.AddEventHandler(adapter, Delegate.CreateDelegate(updEvent.EventHandlerType, handler.Target, handler.Method));
                        }
                        return true;
                    }
                    catch { }
                }
                return false;
            }
            /// <summary>
            /// Registers a <c>RowUpdatingEventHandler</c> with this instance's <c>RowUpdating</c> event.
            /// </summary>
            /// <param name="handler">The event handler to register for the event.</param>
            /// <returns><c>true</c> if the event handler was successfully registered, otherwise <c>false</c>.</returns>
            public static bool AddRowUpdatingHandler(this DbDataAdapter adapter, RowUpdatingEventHandler handler)
            {
                EventInfo updEvent = GetEvent("RowUpdating", adapter.GetType());
                if (updEvent != null)
                {
                    try
                    {
                        if (handler.Method.IsStatic)
                        {
                            updEvent.AddEventHandler(adapter, Delegate.CreateDelegate(updEvent.EventHandlerType, handler.Method));
                        }
                        else
                        {
                            updEvent.AddEventHandler(adapter, Delegate.CreateDelegate(updEvent.EventHandlerType, handler.Target, handler.Method));
                        }
                        return true;
                    }
                    catch { }
                }
                return false;
            }
        }
    }
