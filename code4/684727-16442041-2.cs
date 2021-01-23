    string json = JsonConvert.SerializeObject(new
    {
        results = new List<Result>()
        {
            new Result { id = "1", value = "ABC", info = "ABC" },
            new Result { id = "2", value = "JKL", info = "JKL" }
        }
    });
