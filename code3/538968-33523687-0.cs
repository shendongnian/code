     HttpClient client = new HttpClient();
     HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
           "https://outlook.office.com/api/beta/me/photos('96x96')/$value");
            request.Headers.Add("ACCEPT", "image/*");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
            HttpResponseMessage response = await client.SendAsync(request);
            byte[] byteArray = await response.Content.ReadAsByteArrayAsync();
            string base64ImageRepresentation = Convert.ToBase64String(byteArray);
            if (!response.IsSuccessStatusCode && response.StatusCode >= HttpStatusCode.BadRequest)
            {
                return string.Empty;
            }
            return base64ImageRepresentation;
