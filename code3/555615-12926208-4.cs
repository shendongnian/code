    private Dictionary<String, String> _cameras = new Dictionary<String, String> {
        { "http://example.IPcam1.com:81/snapshot.cgi", "/some/path/for/image1.jpg" },
        { "http://example.IPcam2.com:81/snapshot.cgi", "/some/other/path/image2.jpg" },
    };
    public void DoImageDownload() {
        int finished = 0;
        foreach (KeyValuePair<String, String> pair in _cameras) {
            ThreadPool.QueueUserWorkItem(delegate {
                BeginDownload(pair.Key, pair.Value);
                finished++;
            });
        }
        while (finished < _cameras.Count) {
            Thread.Sleep(1000);  // sleep 1 second
        }
    }
    private void BeginDownload(String src, String dest) {
        WebRequest req = (WebRequest) WebRequest.Create(src);
        req.Credentials = new NetworkCredential("username", "password");
        WebResponse resp = req.GetResponse();
        Stream input = resp.GetResponseStream();
        using (Stream output = File.Create(dest)) {
            input.CopyTo(output);
        }
    }
