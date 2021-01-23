    public void DoImageDownload() {
        foreach (/* image you want to download */) {
            ThreadPool.QueueUserWorkItem(delegate {
                BeginDownload(src, dest);
            });
        }
    }
    private void BeginDownload(String src, String dest) {
        WebRequest req = (WebRequest) WebRequest.Create(src);
        req.Credentials = new NetworkCredential("admin", "icsa2012");
        WebResponse resp = req.GetResponse();
        Stream input = resp.GetResponseStream();
        using (Stream output = File.Create(dest)) {
            input.CopyTo(output);
        }
    }
