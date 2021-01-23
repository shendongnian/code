    var properties = typeof(DespatchRoster ).GetProperties()
        .Where(p => p.IsDefined(typeof(DisplayAttribute), false))
        .Select(p => new
            {
              PropertyName = p.Name, p.GetCustomAttributes(typeof(DisplayAttribute),false)
                              .Cast<DisplayAttribute>().Single().Name
            });
