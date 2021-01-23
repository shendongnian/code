    public Task<IEnumerable<WebResult>> SearchAsync(string query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query cannot be null");
            }
            return Task.Run(() => 
                {
                    DataServiceQuery<WebResult> webQuery = _bingContainer.Web(query, null, null, null, null, null, null, null);
                    return webQuery.Execute();
                }
        }
