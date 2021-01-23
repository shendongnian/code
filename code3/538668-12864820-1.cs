        public MyServiceResponse<Stream> DownloadDocument(string loginName,
                                                                string documentId)
        {
            var proxyWrapper = new MyProxyWrapper<DocumentDownloadResponse>(StreamEndpoint);
            DocumentDownloadResponse response =
                proxyWrapper.Wrap((client) =>
                {
                    Stream data;
                    bool success;
                    string errorMessage = client.DownloadDocument(documentId, loginName,
                                                                  out success,
                                                                  out data);
                    return new DocumentDownloadResponse
                    {
                        Data = data,
                        Success = success,
                        ErrorMessage = errorMessage
                    };
                });
            var result = new MyServiceResponse<Stream>
            {
                Success = response.Success,
                ErrorMessage = response.ErrorMessage
            };
            if (!response.Success)
            {
                result.Data = null;
                response.Data.Close();
            }
            else
            {
                result.Data = response.Data;
            }
            return result;
        }
