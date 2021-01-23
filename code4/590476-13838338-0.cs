    // Abort the request if the timer fires. 
    private static void TimeoutCallback(object state, bool timedOut) { 
        if (timedOut) {
            HttpWebRequest request = state as HttpWebRequest;
                if (request != null) {
                  request.Abort();
            }
        }
    }
