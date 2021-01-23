    #region Don't actually read this terrible code
    // NB: This garbage exists in order to work around the fact that
    // Autofac doesn't support multiple registrations for the same type
    // (i.e. GetAllServices), but RxUI relies on it.
    var registrations = new Dictionary<Tuple<Type, string>, List<Type>>();
    RxApp.ConfigureServiceLocator(
        (t, s) => s != null ? container.ResolveNamed(s, t) : container.Resolve(t),
        (t, s) => {
            var type = typeof(IEnumerable<>).MakeGenericType(t);
            var ret = (IEnumerable<Type>)container.ResolveNamed<IEnumerable<Type>>(type.FullName);
            return ret.Select(x => Activator.CreateInstance(x)).ToArray();
        },
        (c, t, s) => {
            // NB: This is the hackiest hack of hack to work around a bug in RxUI
            if (container != null) return;
            var pair = Tuple.Create(t, s);
            if (!registrations.ContainsKey(pair)) registrations[pair] = new List<Type>();
            registrations[pair].Add(c);
        });
    foreach (var kvp in registrations) {
        if (kvp.Value.Count == 1) {
            var reg = builder.RegisterType(kvp.Value[0]).As(kvp.Key.Item1);
            if (kvp.Key.Item2 != null) reg.Named(kvp.Key.Item2, kvp.Key.Item1);
        } else {
            var type = typeof(IEnumerable<>).MakeGenericType(kvp.Key.Item1);
            builder.RegisterInstance(kvp.Value).As<IEnumerable<Type>>().Named<IEnumerable<Type>>(type.FullName);
        }
    }
    #endregion
