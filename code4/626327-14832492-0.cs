    var items = new List<AssessmentItem>
        {
            new AssessmentItem { ModuleName = "Test 1" },
            new AssessmentItem { ModuleName = "Test 1" },
            new AssessmentItem { ModuleName = "Test 2" },
            new AssessmentItem { ModuleName = "Test 2" },
            new AssessmentItem { ModuleName = "Test 2" }
        };
    var grouped = items.GroupBy(x => x.ModuleName);
    Debug.WriteLine("Distinct modules {0}", grouped.Count());
    foreach (var group in grouped)
    {
        Debug.WriteLine("{0} has {1} entries", group.Key, group.Count());
    }
