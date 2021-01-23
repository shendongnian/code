    public static string GetHeader(this HttpRequestMessage request, string key)
            {
                IEnumerable<string> keys = null;
                if (!request.Headers.TryGetValues(key, out keys))
                    return null;
    
                return keys.First();
            }
