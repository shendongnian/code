    var genericArguments = typeof(ValueImplementation<,>).GetGenericArguments();
    var implementedInterfaces = typeof(ValueImplementation<,>).GetInterfaces();
    foreach (Type _interface in implementedInterfaces) {
        for (int i = 0; i < genericArguments.Count(); i++) {
            if (_interface.GetGenericArguments().Contains(genericArguments[i])) {
                Console.WriteLine("Interface {0} implements T{1}", _interface.Name, i + 1);
            }
        }
    }
