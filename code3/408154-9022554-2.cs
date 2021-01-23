    var list = Special_texts.Where(x=> x.Name.Equals("ExceptionList"))
                            .Select(x=> x.Content)
                            .AsEnumerable()
                            .Select(x=> x.Split(new [] {'#'}, StringSplitOptions.RemoveEmptyEntries))
                            .SelectMany(x=> x)
                            .ToList();
