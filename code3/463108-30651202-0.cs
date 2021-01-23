                var jsonString = JsonConvert.SerializeObject(new { name = "newFile.txt", type = "File" }); 
                 
                HttpContent httpContent = new StringContent(jsonString);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue ("application/json");          
                HttpClient hc = new HttpClient();
                //add the header with the access token
                hc.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
               
                //make the put request
                HttpResponseMessage hrm = (await hc.PostAsync(requestUrl, httpContent));
                if (hrm.IsSuccessStatusCode)
                {
//
}
