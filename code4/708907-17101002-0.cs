            var myDatas = new[]
            {
                new Tuple<string, string, DateTime>("Title", "Example", DateTime.Now),
                new Tuple<string, string, DateTime>("Title2", "Example", DateTime.Now.AddDays(-1)),
                new Tuple<string, string, DateTime>("Title3", "Example", DateTime.Now.AddDays(1))
            };
            var contents = myDatas.Select(e => new Content
            {
                Title = e.Item1,
                Text = e.Item2,
                ModifiedDate = DateTime.Now
            });
