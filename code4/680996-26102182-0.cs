      var settings = new JsonSerializerSettings()
            {
                DateFormatHandling =
                    DateFormatHandling.MicrosoftDateFormat
            };
            var serializedString = JsonConvert.SerializeObject(data, settings);
            var conent = new StringContent(serializedString);
            conent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await this.httpClient.PostAsync(requestUri, conent).ConfigureAwait(false);
            T requestResult = default(T);
            if (response.IsSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
                requestResult = await response.Content.ReadAsAsync<T>();
            }
