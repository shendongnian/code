    List<Activity> activities = …;
    var result = activities.RecursiveSelect(
        (s, a) =>
        new Dictionary<string, object>
        { 
            { "id", a.Id },
            { "title", a.ActivityTitle },
            { "children", a.Children.Select(c => s(s, c)).ToArray() }
        });
