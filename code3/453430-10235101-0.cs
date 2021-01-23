	test
        .ToCharArray()
        .Reverse()
        .SkipWhile(c =>
        {
            int i;
            return !int.TryParse(c.ToString(), out i);
        })
        .TakeWhile(c => c != '_');
