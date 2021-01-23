    public async Task<T> GetItemAsync<T>(string id)
                {
                    try
                    {
                        var response = await this._container.ReadItemAsync<T>(id, new PartitionKey(id));
                        return response.Resource;
                    }
                    catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        
                        return default(T);
                    }
    
                }
