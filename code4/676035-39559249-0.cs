        private static async Task<byte[]> downloadDataAsync(Uri uri, CancellationToken cancellationToken)
        {
            if (String.IsNullOrWhiteSpace(uri.ToString()))
                throw new ArgumentNullException(nameof(uri), "Uri can not be null or empty.");
            if (!Uri.IsWellFormedUriString(uri.ToString(), UriKind.Absolute))
                return null;
            byte[] dataArr = null;
            try
            {
                using (var webClient = new WebClient())
                using (var registration = cancellationToken.Register(() => webClient.CancelAsync()))
                {
                    dataArr = await webClient.DownloadDataTaskAsync(uri);
                }
            }
            catch
            {
                //throw errors not related to cancellation
                if (!(ex is WebException && (ex as WebException).Status == WebExceptionStatus.RequestCanceled)) 
                   throw new WebException("Unable to download data. Uri: " + uri);
            }
            return dataArr;
        }
