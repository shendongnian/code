    public static class DispatcherTestHelper
    {
        private static DispatcherOperationCallback exitFrameCallback = ExitFrame;
        /// <summary>
        /// Synchronously processes all work items in the current dispatcher queue.
        /// </summary>
        /// <param name="minimumPriority">
        /// The minimum priority. 
        /// All work items of equal or higher priority will be processed.
        /// </param>
        public static void ProcessWorkItems(DispatcherPriority minimumPriority)
        {
            var frame = new DispatcherFrame();
            // Queue a work item.
            Dispatcher.CurrentDispatcher.BeginInvoke(
                minimumPriority, exitFrameCallback, frame);
            // Force the work item to run.
            // All queued work items of equal or higher priority will be run first. 
            Dispatcher.PushFrame(frame);
        }
        private static object ExitFrame(object state)
        {
            var frame = (DispatcherFrame)state;
            // Stops processing of work items, causing PushFrame to return.
            frame.Continue = false;
            return null;
        }
    }
