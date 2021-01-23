    public static async Task<string> HttpPut(string inUrl, string inFilePath)
        {
            using (var client = new HttpClient())
            {
                using (var content = new StreamContent(File.OpenRead(inFilePath)))
                {
                    content.Headers.Remove("Content-Type");
                    content.Headers.Add("Content-Type", "application/octet-stream");
                    using (var req = new HttpRequestMessage(HttpMethod.Put, inUrl))
                    {
                        string authInfo = String.Format("{0}:{1}", Program.Config.MediaStorageList.Find(o => o.Name == "Viz Media Engine Test").UserName, Program.Config.MediaStorageList.Find(o => o.Name == "Viz Media Engine Test").Password);
                        authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                        req.Headers.Add("Authorization", "Basic " + authInfo);
                        req.Headers.Remove("Expect");
                        req.Headers.Add("Expect", "");
                        req.Content = content;
                        // Ignore Certificate validation failures (aka untrusted certificate + certificate chains)
                        ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
                        using (HttpResponseMessage resp = await client.SendAsync(req))
                        {
                            resp.EnsureSuccessStatusCode();
                            return await resp.Content.ReadAsStringAsync();
                        }
                    }
                }
            }
        }
