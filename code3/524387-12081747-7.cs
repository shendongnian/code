    Animal a = new Animal();
    a.Message = "öçşistltl";
    var URI = "http://localhost/Values/DoSomething";
    using (var client = new HttpClient())
    {
        client
            .PostAsync<Animal>(URI, a, new JsonMediaTypeFormatter())
            .ContinueWith(x => x.Result.Content.ReadAsStringAsync().ContinueWith(y =>
            {
                Console.WriteLine(y.Result);
            }))
            .Wait();
    }
