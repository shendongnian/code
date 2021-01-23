      Task<JsonResult<MyResult>> message = Task.Factory.StartNew<HttpRequestMessage>(state =>  {
                Console.WriteLine(state.ToString() + " started");
                return client.SendAsync(request).Result;
            }, i )
                .ContinueWith<JsonResult<MyResult>>((r) =>
                {
                    var stringresult = r.Result.Content.ReadAsStringAsync().Result;
                    var deserialized = JsonConvert.DeserializeObject<JsonResult<MyResult>>(stringresult);
                    Console.WriteLine(deserialized.Id + " deserialized");
                    return deserialized;
                })
                .ContinueWith<JsonResult<MyResult>>(m =>
                {
                    Console.WriteLine(m.Id + " completed");
                    return m.Result;
                });
