        using (WebResponse response = request.GetResponse())
        {
            foreach (var headerKey in response.Headers.Keys)
            {
                var headerValues = response.Headers.GetValues(headerKey.ToString());
                Trace.TraceInformation("Header: {0}, Value :{1}", headerKey, String.Join(";",headerValues));
            }
        }
