    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    public sealed class HostEntryTimeout {
        public IPHostEntry HostEntry {
            get;
            private set;
        }
        string _hostName;
        int _timeoutInMilliseconds;
        ManualResetEvent _getHostEntryFinished;
        public HostEntryTimeout(string alias, int timeoutInMilliseconds) {
            _hostName = alias;
            _timeoutInMilliseconds = timeoutInMilliseconds;
            _getHostEntryFinished = new ManualResetEvent(false);
        }
        /// <summary>
        /// Gets the IPHostEntry.
        /// </summary>
        /// <returns>True if successful, false otherwise.</returns>
        public bool GetHostEntry() {
            _getHostEntryFinished.Reset();
            Dns.BeginGetHostEntry(_hostName, GetHostEntryCallback, null);
            if (!_getHostEntryFinished.WaitOne(_timeoutInMilliseconds)) {
                return false;
            }
            if (HostEntry == null) {
                return false;
            }
            return true;
        }
        void GetHostEntryCallback(IAsyncResult asyncResult) {
            try {
                HostEntry = Dns.EndGetHostEntry(asyncResult);
            } catch (SocketException) {
            }
            _getHostEntryFinished.Set();
        }
    }
