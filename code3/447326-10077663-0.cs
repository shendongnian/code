            HttpClient client = new HttpClient();
            var task = client.PostAsync(string.Format("{0}{1}", "http://localhost/myAPI", "?options=blue&type=car"), null);
            Car car = task.ContinueWith(
                t =>
                {
                    return t.Result.Content.ReadAsAsync<Car>();
                }).Unwrap().Result;
