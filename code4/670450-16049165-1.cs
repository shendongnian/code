    var query = path.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries)
        .Aggregate(new List<string>(), (memo, segment) => {
            memo.Add(memo.DefaultIfEmpty("").Last() + "/" + segment);
            return memo;
        }).Aggregate(new List<string>(), (memo, p) => {
            memo.Add(p);
            memo.Add(p + "/default");
            return memo;
        });
