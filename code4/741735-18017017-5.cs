    Action<object> action = null;
    for (Type t = a.GetType(); t = t.BaseType; t != null) {
        if (typeActions.TryGetValue(t, out action)) {
            break;
        }
    }
    if (action != null) {
        action(a);
    }
