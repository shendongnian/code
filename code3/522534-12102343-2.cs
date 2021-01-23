    public static class DispatcherTestHelper
    {
        private static DispatcherOperationCallback exitFrameCallback = ExitFrame;
        /// <summary>
        /// Synchronously processes all work items with DispatcherPriority Background
        /// or higher in the current dispatcher work item queue.
        /// </summary>
        public static void ProcessWorkItems()
        {
            var frame = new DispatcherFrame();
            // When we explicitly run this work item, all currently queued work items
            // of equal or higher priority will be run.  
            Dispatcher.CurrentDispatcher.BeginInvoke(
                DispatcherPriority.Background, 
                exitFrameCallback, 
                frame);
                // Run the work item.
                Dispatcher.PushFrame(frame);
                }
                private static object ExitFrame(object state)
                {
                    var frame = (DispatcherFrame)state;
                    // Tells the Dispatcher to stop processing work items,
                    // causing PushFrame to return.
                    frame.Continue = false;
                    return null;
                }
    }
