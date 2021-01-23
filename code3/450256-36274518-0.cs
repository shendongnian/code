        public async Task<IRestResponse<T>> ExecuteAsync<T>(IRestRequest request) where T : class, new()
        {
            var client = new RestClient(_settingsViewModel.BaseUrl);
            var taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();
            client.ExecuteAsync<T>(request, restResponse =>
            {
                if (restResponse.ErrorException != null)
                {
                    const string message = "Error retrieving response.";
                    throw new ApplicationException(message, restResponse.ErrorException);
                }
                taskCompletionSource.SetResult(restResponse);
            });
            return await taskCompletionSource.Task;
        }
