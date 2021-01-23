    private void LogResponse(HttpResponseMessage response)
    {
        ApiResponse info = new ApiResponse();
        //Populate response obj   
        if (response.Content != null)
        {
            var info = await response.Content.ReadAsStringAsync();
            _repository.LogResponse(info);
        }
    }
