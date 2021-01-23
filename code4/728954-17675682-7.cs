    typeof(Employee)
        .GetProperties()
        .Select((p, index) =>
            new { Index = index, PropertyInfo = p })
        .ToList()
        .ForEach(p =>
            {
                typeof(Manager)
                    .GetProperties()
                    .Skip(p.Index)
                    .FirstOrDefault()
                    .SetValue(manager,
                        p.PropertyInfo.GetValue(employee));
            });
