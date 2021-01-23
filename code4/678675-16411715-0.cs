    int maxAttempts = 5;
    for (int attempt = 1; attempt <= maxAttempts; attempt++) {
        try {
            if (attempt > 1) {
                 // Wait a few seconds
                 Thread.Sleep(new TimeSpan(0, 0, 10));
                 Logger.Output(string.Format("Retrying request, try: {0}", attempt));
            }
            using (var webClient = new WebClient()) {
                webClient.Headers.Add("Content-Type", string.Format("multipart/form-data; boundary={0}", boundary));
                Logger.Output(webClient.Headers.ToString());
                var response1 = webClient.UploadData(address, "POST", buffer);
            }
            Logger.Output("Table {0} added successfully", table);
            break;
        } catch (WebException e) {
            // More logging here
            if (attempt == maxAttempts) {
                throw; // Re-throw it, clearly something is wrong if it fails x times.
            }
        }
    }
