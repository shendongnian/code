    public async Task<IEnumerable<Document>> GetAll()
    {
        try
        {
            var response = await _client.GetAsync(
                           string.Format("{0}/api/document", _baseURI))
                               .ConfigureAwait(false);
    
            // never hits line below
            return await response.Content.ReadAsAsync<Document>() 
                       as IEnumerable<Document>;
        }
        catch (Exception ex)
        {
            // handle exception
        }
    }
