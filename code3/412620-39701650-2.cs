    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://localhost:9000/");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
        var foo = new User
        {
            user = "Foo",
            password = "Baz"
        }
    
        await client.PostAsJsonAsync("users/add", foo);
    }
