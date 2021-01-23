    public class DownloadJob {
        public delegate void DownloadCompletedDelegate(Stream stream);
        //completion download  event
        public event DownloadCompletedDelegate OnDownloadCompleted;
        //sync object
        private object _lock = new object();
        //pause flag
        private bool _bPause = false;
        //Pause download
        public void Pause() {
            lock (_lock) {
                _bPause = true;
            }
        }
        //Resume download
        public void Resume() {
            lock (_lock) {
                _bPause = false;
            }
        }
        //Begin download with URI
        public void BeginDowload(Uri uri) {
            
            //Create Background thread
            Thread downLoadThread = new Thread(
                delegate() {
                    WebRequest pWebReq = WebRequest.Create(uri);
                    WebResponse pWebRes = pWebReq.GetResponse();
                    using (MemoryStream pResultStream = new MemoryStream())
                    using (Stream pWebStream = pWebRes.GetResponseStream()) {
                        byte[] buffer = new byte[256];
                        int readCount = 1;
                        while (readCount > 0) {
                            //Read download stream 
                            readCount = pWebStream.Read(buffer, 0, buffer.Length);
                            //Write to result MemoryStream
                            pResultStream.Write(buffer, 0, readCount);
                            //Waiting 100msec while _bPause is true
                            while (true) {
                                lock (_lock) {
                                    if (_bPause == true) {
                                        Thread.Sleep(100);
                                    }
                                    else {
                                        break;
                                    }
                                }
                            }
                            pResultStream.Flush();
                        }
                        //Fire Completion event
                        if (OnDownloadCompleted != null) {
                            OnDownloadCompleted(pResultStream);
                        }
                    }
                }
            );
            //Start background thread job
            downLoadThread.Start();
        }
    }
