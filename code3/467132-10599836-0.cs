    private System.Drawing.Image GetImage(string URI)
        {
            WebClient webClient = new WebClient();
            byte[] data = webClient.DownloadData(URI);
            MemoryStream memoryStream = new MemoryStream(data);
            return System.Drawing.Image.FromStream(memoryStream);
        }
