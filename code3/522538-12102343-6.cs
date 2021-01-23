    public static class DispatcherTestHelper
    {
        private static DispatcherOperationCallback exitFrameCallback = ExitFrame;
        /// <summary>
        /// Synchronously processes all work items
        /// in the current dispatcher work item queue.
        /// </summary>
        /// <param name="minimumPriority">
        /// The minimum priority. 
        /// All work items of equal or higher priority will be processed.
        /// </param>
        public static void ProcessWorkItems(DispatcherPriority minimumPriority)
        {
            var frame = new DispatcherFrame();
            // When we explicitly run this work item, all currently queued work items
            // of equal or higher priority will be run.
            Dispatcher.CurrentDispatcher.BeginInvoke(
                minimumPriority, exitFrameCallback, frame);
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
