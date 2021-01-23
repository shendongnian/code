            .ContinueWith<JsonResult<MyResult>>(m =>
            {
                Console.WriteLine(m.Result.Id + " completed");
                return m.Result;
            });
