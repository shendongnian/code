    public class WebClientAdvanced : WebClient
    {
        public async Task<byte[]> UploadValuesAsync(string address, string method, IDictionary<string, string> data)
        {
            var nvc = new NameValueCollection();
            foreach (var x in data) nvc.Add(x.Key, x.Value.ToStr());
            var tcs = new TaskCompletionSource<byte[]>();
            UploadValuesCompleted += (s, e) =>
            {
                if (e.Cancelled) tcs.SetCanceled();
                else if (e.Error != null) tcs.SetException(e.Error);
                else tcs.SetResult(e.Result);
            };
            UploadValuesAsync(new Uri(address), method, nvc);
            var result = await tcs.Task;
            return result;
        }
    }
