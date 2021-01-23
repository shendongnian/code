            try
            {
                var response = await httpClient.PostAsync(uri, content);
                if (!response.IsSuccessStatusCode)
                {
                    // handle the second type of error (404, 400, etc.)
                }
            }
            catch (HttpRequestException ex)
            {
                // handle the first type of error (no connectivity, etc)
            }
