        private void buttonTest_Click(object sender, EventArgs e)
        {
            CheckSystemEventsHandlersForFreeze();
        }
        private static void CheckSystemEventsHandlersForFreeze()
        {
            var handlers = typeof(SystemEvents).GetField("_handlers", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
            var handlersValues = handlers.GetType().GetProperty("Values").GetValue(handlers);
            foreach (var invokeInfos in (handlersValues as IEnumerable).OfType<object>().ToArray())
            foreach (var invokeInfo in (invokeInfos as IEnumerable).OfType<object>().ToArray())
            {
                var syncContext = invokeInfo.GetType().GetField("_syncContext", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(invokeInfo);
                if (syncContext == null) throw new Exception("syncContext missing");
                if (!(syncContext is WindowsFormsSynchronizationContext)) continue;
                var threadRef = (WeakReference) syncContext.GetType().GetField("destinationThreadRef", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(syncContext);
                if (!threadRef.IsAlive) continue;
                var thread = (Thread)threadRef.Target;
                if (thread.ManagedThreadId == 1) continue;  // Change here if you have more valid UI threads to ignore
                var dlg = (Delegate) invokeInfo.GetType().GetField("_delegate", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(invokeInfo);
                MessageBox.Show($"SystemEvents handler '{dlg.Method.DeclaringType}.{dlg.Method.Name}' could freeze app due to wrong thread: "
                                + $"{thread.ManagedThreadId},{thread.IsThreadPoolThread},{thread.IsAlive},{thread.Name}");
            }
        }
