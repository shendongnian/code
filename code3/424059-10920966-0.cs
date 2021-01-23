        /// <summary>
        /// Executes function proc on a separate thread respecting the given timeout value.
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="proc">The function to execute.</param>
        /// <param name="timeout">The timeout duration.</param>
        /// <returns></returns>
        public static R ExecuteWithTimeout<R>(Func<R> proc, TimeSpan timeout) {
            var r = default(R); // init default return value
            Exception ex = null; // records inter-thread exception
            // define a thread to wrap 'proc'
            var t = new Thread(() => {
                try {
                    r = proc();
                    }
                catch (Exception e) {
                    // this can get set to ThreadAbortException
                    ex = e;
                    Debug.WriteLine("Exception hit");
                    }
                });
            t.Start(); // start running 'proc' thread wrapper
            // from docs: "The Start method does not return until the new thread has started running."
            if (t.Join(timeout) == false) {
                t.Abort(); // die evil thread!
                // Abort raises the ThreadAbortException
                int i = 0;
                while ((t.Join(1) == false) && (i < 20)) { // 20 ms wait possible here
                    i++;
                    }
                if (i >= 20) {
                    // we didn't abort, might want to log this or take some other action
                    // this can happen if you are doing something indefinitely hinky in a
                    // finally block (cause the finally be will executed before the Abort 
                    // completes.
                    Debug.WriteLine("Abort didn't work as expected");
                    }
                }
            if (ex != null) {
                throw ex; // oops
                }
            return r; // ah!
            } 
