     public override IEnumerable<Contact> Fill(IEnumerable<int> ids)
        {
            IEnumerable<Contact> result = null;
            if (ids!=null&&ids.Count()>0)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:49520/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        String _endPoint = "api/" + typeof(Contact).Name + "/ListArray";
                        HttpResponseMessage response = client.PostAsJsonAsync<IEnumerable<int>>(_endPoint, ids).Result;
                        response.EnsureSuccessStatusCode();
                        if (response.IsSuccessStatusCode)
                        {
                            result = JsonConvert.DeserializeObject<IEnumerable<Contact>>(response.Content.ReadAsStringAsync().Result);
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
            return result;
        }
