        var processedData =
            rawData.GroupBy(bugs => bugs.bug_category,
                (category, elements) =>
                new
                    {
                        Category = category,
                        Bugs = elements.GroupBy(bugs => bugs.bug_priority,
                                            (priority, realbugs) =>
                                            new
                                                {
                                                    Priority = priority,
                                                    Count = realbugs.Count()
                                                })
                    });
        foreach (var data in processedData)
        {
            Console.WriteLine(data.Category);
            foreach (var element in data.Bugs)
                Console.WriteLine("  " + element.Priority + " = " + element.Count);
        }
