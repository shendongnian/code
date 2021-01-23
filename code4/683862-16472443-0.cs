    internal async Task Download(CloudBlobClient client)
        {
            try
            {
                _media = await _directory.CreateFileAsync(ResourceName, CreationCollisionOption.FailIfExists);
            }
            catch (Exception)
            {
                return;
            }
            try
            {
                    var blob = await GetBlob(client);
                    HttpClient httpClient = new HttpClient();
                    var date = DateTime.UtcNow;
                    var policy = new SharedAccessBlobPolicy();
                    policy.Permissions = SharedAccessBlobPermissions.Read;
                    policy.SharedAccessStartTime = new DateTimeOffset(date);
                    policy.SharedAccessExpiryTime = new DateTimeOffset(date.AddDays(1));
                    var signature = blob.GetSharedAccessSignature(policy);
                    var uriString = string.Format("{0}{1}", blob.Uri.ToString(), signature);
                    var data = await httpClient.GetByteArrayAsync(uriString);
                    var buf = new Windows.Storage.Streams.Buffer((uint)data.Length);
                    await FileIO.WriteBytesAsync(_media, data);
                    _category.NotifyAzureProgress();
                
            }
            catch (Exception e)
            {
                _media.DeleteAsync();
                throw e;
            }
        }
